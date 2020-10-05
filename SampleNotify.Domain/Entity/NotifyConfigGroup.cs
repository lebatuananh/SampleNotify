using System.Collections.Generic;

namespace SampleNotify.Models.Entity
{
    public class NotifyConfigGroup
    {
        public NotifyConfigGroup(string title, int ord, string appId)
        {
            Title = title;
            Ord = ord;
            AppId = appId;
        }


        public int Id { get; set; }
        public string Title { get; set; }
        public int Ord { get; set; }
        public string AppId { get; set; }
        public virtual ICollection<NotifyConfig> NotifyConfig { get; set; }


        public void Update(string title, int ord, string appId)
        {
            Title = title;
            Ord = ord;
            AppId = appId;
        }
    }
}