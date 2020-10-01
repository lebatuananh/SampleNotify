using SampleNotify.Models.AggregateModels.NotifyConfigGroupAggregate;
using Shared.EF.Interfaces;

namespace SampleNotify.Models.AggregateModels.NotifyConfigAggregate
{
    public class NotifyConfig:IAggregateRoot
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool Required { get; set; }

        public virtual NotifyConfigGroup Group { get; set; }
    }
}