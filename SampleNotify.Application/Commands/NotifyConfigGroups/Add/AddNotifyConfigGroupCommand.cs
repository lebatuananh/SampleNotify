using MediatR;

namespace SampleNotify.Application.Commands.NotifyConfigGroups.Add
{
    public class AddNotifyConfigGroupCommand:IRequest
    {
        public AddNotifyConfigGroupCommand(string title, int ord, string appId)
        {
            Title = title;
            Ord = ord;
            AppId = appId;
        }

        public string Title { get; private set; }
        public int Ord { get; private set; }
        public string AppId { get; private set; }
    }
}