using FluentValidation;
using MediatR;
using SampleNotify.Models.Repositories.Interfaces;

namespace SampleNotify.Application.Commands.NotifyConfigGroups
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
}