namespace SampleNotify.Application.Models.NotifyConfigGroup
{
    public class NotifyConfigGroupDto
    {
        public NotifyConfigGroupDto(int id, string title, int ord, string appId)
        {
            Id = id;
            Title = title;
            Ord = ord;
            AppId = appId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Ord { get; set; }
        public string AppId { get; set; }
    }
}