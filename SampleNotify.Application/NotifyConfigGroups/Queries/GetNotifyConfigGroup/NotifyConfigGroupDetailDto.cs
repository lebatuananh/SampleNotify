namespace SampleNotify.Application.NotifyConfigGroups.Queries.GetNotifyConfigGroup
{
    public class NotifyConfigGroupDetailDto
    {
        public NotifyConfigGroupDetailDto(int id, string title, int ord)
        {
            Id = id;
            Title = title;
            Ord = ord;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Ord { get; set; }
    }
}