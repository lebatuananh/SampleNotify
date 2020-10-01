using System.Collections.Generic;
using SampleNotify.Models.AggregateModels.NotifyConfigAggregate;
using Shared.EF.Interfaces;

namespace SampleNotify.Models.AggregateModels.NotifyConfigGroupAggregate
{
    public class NotifyConfigGroup : IAggregateRoot
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Ord { get; set; }
        public string AppId { get; set; }
        public virtual ICollection<NotifyConfig> NotifyConfig { get; set; }

        public NotifyConfigGroup(string title, int ord, string appId)
        {
            Title = title;
            Ord = ord;
            AppId = appId;
        }

        public void Update(string title, int ord, string appId)
        {
            Title = title;
            Ord = ord;
            AppId = appId;
        }
    }
}