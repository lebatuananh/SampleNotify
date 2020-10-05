using FluentValidation;
using MediatR;
using SampleNotify.Models.Repositories.Interfaces;

namespace SampleNotify.Application.Commands.NotifyConfigGroups
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
}