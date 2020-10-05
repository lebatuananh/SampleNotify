using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SampleNotify.Models;
using SampleNotify.Models.Entity;
using SampleNotify.Models.Repositories.Interfaces;
using Shared.BaseModel;
using Shared.EF.Interfaces;

namespace SampleNotify.Application.NotifyConfigGroups.Commands
{
    public class AddNotifyConfigGroupCommand : IRequest<BaseEntityResponse<NotifyConfigGroup>>
    {
        public AddNotifyConfigGroupCommand(string title, int ord, string appId)
        {
            Title = title;
            Ord = ord;
            AppId = appId;
        }

        public string Title { get; }
        public int Ord { get; }
        public string AppId { get; }
    }

    public class AddNotifyConfigGroupCommandValidator : AbstractValidator<AddNotifyConfigGroupCommand>
    {
        public AddNotifyConfigGroupCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithErrorCode("TITLE_NOT_ALLOW_NULL")
                .MaximumLength(100)
                .WithErrorCode("TITLE_LENGTH_OVER_LIMIT")
                .WithState(_ => new Dictionary<string, string> {{"TITLE_MAX_LENGTH", "100"}});
            RuleFor(x => x.Ord)
                .NotNull()
                .WithErrorCode("ORDER_NOT_ALLOW_NULL")
                .GreaterThan(0)
                .WithErrorCode("ORD_VALUE_INVALID")
                .WithState(_ => new Dictionary<string, string> {{"ORD_MIN_VALUE", "1"}});
            RuleFor(x => x.AppId)
                .NotEmpty()
                .WithErrorCode("APP_ID_NOT_ALLOW_NULL");
        }
    }

    public class
        AddNotifyConfigGroupCommandHandler : IRequestHandler<AddNotifyConfigGroupCommand,
            BaseEntityResponse<NotifyConfigGroup>>
    {
        private readonly INotifyConfigGroupRepository _notifyConfigGroupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddNotifyConfigGroupCommandHandler(INotifyConfigGroupRepository notifyConfigGroupRepository,
            IUnitOfWork unitOfWork)
        {
            _notifyConfigGroupRepository = notifyConfigGroupRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseEntityResponse<NotifyConfigGroup>> Handle(AddNotifyConfigGroupCommand request,
            CancellationToken cancellationToken)
        {
            var response = new BaseEntityResponse<NotifyConfigGroup>(true, null);
            var query = _notifyConfigGroupRepository.Add(new NotifyConfigGroup(request.Title, request.Ord,
                request.AppId));
            response.SetData(query);
            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }
    }
}