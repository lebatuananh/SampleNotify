using FluentValidation;
using SampleNotify.Models.AggregateModels.NotifyConfigGroupAggregate;

namespace SampleNotify.Application.Commands.NotifyConfigGroups.Delete
{
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
}