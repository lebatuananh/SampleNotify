using FluentValidation;

namespace SampleNotify.Application.Commands.NotifyConfigGroups.Add
{
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