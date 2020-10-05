using FluentValidation;
using MediatR;

namespace SampleNotify.Application.Commands.NotifyConfigGroups
{
    public class AddNotifyConfigGroupCommand : IRequest
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
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is not null");
            RuleFor(x => x.Ord).NotNull().WithMessage("Order is not null");
            RuleFor(x => x.AppId).NotEmpty().WithMessage("AppId is not null");
        }
    }
}