using MediatR;

namespace SampleNotify.Application.Commands.NotifyConfigGroups.Delete
{
    public class DeleteNotifyConfigGroupCommand:IRequest
    {
        public int Id { get; private set; }

        public DeleteNotifyConfigGroupCommand(int id)
        {
            Id = id;
        }
    }
}