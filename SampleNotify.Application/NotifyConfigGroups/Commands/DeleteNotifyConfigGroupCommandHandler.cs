using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SampleNotify.Models.Repositories.Interfaces;
using Shared.EF.Interfaces;

namespace SampleNotify.Application.NotifyConfigGroups.Commands
{
    public class DeleteNotifyConfigGroupCommand : IRequest
    {
        public DeleteNotifyConfigGroupCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }

    public class DeleteNotifyConfigGroupCommandValidator : AbstractValidator<DeleteNotifyConfigGroupCommand>
    {
        public DeleteNotifyConfigGroupCommandValidator(INotifyConfigGroupRepository notifyConfigGroupRepository)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is not null");

            RuleFor(command => command).Custom((command, context) =>
            {
                var notifyConfigGroup = notifyConfigGroupRepository.GetByIdAsync(command.Id).GetAwaiter().GetResult();
                if (notifyConfigGroup == null)
                    context.AddFailure($"{nameof(command.Id)}", $"NotifyConfigGroup#{command.Id} could not be found.");
            });
        }
    }

    public class DeleteNotifyConfigGroupCommandHandler : IRequestHandler<DeleteNotifyConfigGroupCommand>
    {
        private readonly INotifyConfigGroupRepository _notifyConfigGroupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteNotifyConfigGroupCommandHandler(INotifyConfigGroupRepository notifyConfigGroupRepository,
            IUnitOfWork unitOfWork)
        {
            _notifyConfigGroupRepository = notifyConfigGroupRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Unit> Handle(DeleteNotifyConfigGroupCommand request, CancellationToken cancellationToken)
        {
            _notifyConfigGroupRepository.Delete(request.Id);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}