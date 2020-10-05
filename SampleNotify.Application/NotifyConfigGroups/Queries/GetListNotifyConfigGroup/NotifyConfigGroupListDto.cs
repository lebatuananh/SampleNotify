namespace SampleNotify.Application.NotifyConfigGroups.Queries.GetListNotifyConfigGroup
{
    public class NotifyConfigGroupListDto
    {
        public NotifyConfigGroupListDto(int id, string title, int ord)
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