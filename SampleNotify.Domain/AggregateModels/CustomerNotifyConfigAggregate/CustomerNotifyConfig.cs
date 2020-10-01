using Shared.EF.Interfaces;

namespace SampleNotify.Models.AggregateModels.CustomerNotifyConfigAggregate
{
    public class CustomerNotifyConfig:IAggregateRoot
    {
        public int Id { get; set; }
        /// <summary>
        /// Mã App (VD: ichiba-portal-web)
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// CustomerId
        /// </summary>
        public string AccountId { get; set; }
        public string NotifyConfigCode { get; set; }
        public bool SendEmail { get; set; }
        public bool SendWeb { get; set; }
        public bool SendMobile { get; set; }
        public bool SendDesktop { get; set; }
    }
}