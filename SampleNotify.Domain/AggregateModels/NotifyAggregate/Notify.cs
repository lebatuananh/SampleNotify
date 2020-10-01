using System;
using Shared.EF.Interfaces;

namespace SampleNotify.Models.AggregateModels.NotifyAggregate
{
    public class Notify:IAggregateRoot
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        public string Badge { get; set; }
        public string Body { get; set; }
        public string ClickAction { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? DontSendBeforeDateUtc { get; set; }
        public string JsonData { get; set; }
        public string Link { get; set; }
        public string ListTo { get; set; }
        public int? ListToType { get; set; }
        public string ListToTypeText { get; set; }
        public int? Priority { get; set; }
        public string PriorityText { get; set; }
        public string RefCode { get; set; }
        public string RefType { get; set; }
        public bool? RequireInteraction { get; set; }
        public string RoutingKey { get; set; }
        public int? SendStatus { get; set; }
        public string SendStatusText { get; set; }
        public DateTime? SentOnUtc { get; set; }
        public int? SentTries { get; set; }
        public string Sound { get; set; }
        public string Title { get; set; }
    }
}