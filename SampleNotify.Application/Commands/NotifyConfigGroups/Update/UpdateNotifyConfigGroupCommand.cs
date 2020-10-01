using MediatR;

namespace SampleNotify.Application.Commands.NotifyConfigGroups.Update
{
    public class UpdateNotifyConfigGroupCommand:IRequest
    {
        public UpdateNotifyConfigGroupCommand(int id,string title, int ord, string appId)
        {
            Title = title;
            Ord = ord;
            AppId = appId;
            Id = id;
        }

        public int Id { get; set; }
        public string Title { get; private set; }
        public int Ord { get; private set; }
        public string AppId { get; private set; }
    }
}