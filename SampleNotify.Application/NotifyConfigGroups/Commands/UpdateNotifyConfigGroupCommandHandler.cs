using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SampleNotify.Models.Repositories.Interfaces;
using Shared.EF.Interfaces;

namespace SampleNotify.Application.NotifyConfigGroups.Commands
{
    public class UpdateNotifyConfigGroupCommand : IRequest
    {
        public UpdateNotifyConfigGroupCommand(int id, string title, int ord, string appId)
        {
            Title = title;
            Ord = ord;
            AppId = appId;
            Id = id;
        }

        public int Id { get; set; }
        public string Title { get; }
        public int Ord { get; }
        public string AppId { get; }
    }

    public class UpdateNotifyConfigGroupCommandValidator : AbstractValidator<UpdateNotifyConfigGroupCommand>
    {
        public UpdateNotifyConfigGroupCommandValidator(INotifyConfigGroupRepository notifyConfigGroupRepository)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is not null");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is not null");
            RuleFor(x => x.Ord).NotNull().WithMessage("Order is not null");
            RuleFor(x => x.AppId).NotEmpty().WithMessage("AppId is not null");

            RuleFor(command => command).Custom((command, context) =>
            {
                var notifyConfigGroup = notifyConfigGroupRepository.GetByIdAsync(command.Id).GetAwaiter().GetResult();
                if (notifyConfigGroup == null)
                    context.AddFailure($"{nameof(command.Id)}", $"NotifyConfigGroup#{command.Id} could not be found.");
            });
        }
    }

    public class UpdateNotifyConfigGroupCommandHandler : IRequestHandler<UpdateNotifyConfigGroupCommand>
    {
        private readonly INotifyConfigGroupRepository _notifyConfigGroupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNotifyConfigGroupCommandHandler(INotifyConfigGroupRepository notifyConfigGroupRepository,
            IUnitOfWork unitOfWork)
        {
            _notifyConfigGroupRepository = notifyConfigGroupRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateNotifyConfigGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _notifyConfigGroupRepository.GetByIdAsync(request.Id);
            entity.Update(request.Title, request.Ord, request.AppId);
            _notifyConfigGroupRepository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}