using System;
using Shared.EF.Interfaces;

namespace SampleNotify.Models.AggregateModels.EmailTemplateAggregate
{
    public class EmailTemplate:IAggregateRoot
    {
        /// <summary>
        /// Guid.NewGuid().ToString()
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Mã App (VD: ichiba-portal-web)
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// Mã thông báo của App (VD: NotifyConfigCodes.Orders.Transport.OrderPlaced)
        /// </summary>
        public string AppNotifyConfigCode { get; set; }

        /// <summary>
        /// Nhóm cấu hình (Enum: NotifyConfigGroup)
        /// </summary>
        public int? GroupType { get; set; }

        /// <summary>
        /// Mã ngôn ngữ (VD: vi-VN, en-US)
        /// </summary>
        public string LanguageCulture { get; set; }

        /// <summary>
        /// Tên Template
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Tiêu đề
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Nội dung Html
        /// </summary>
        public string HtmlBody { get; set; }

        /// <summary>
        /// Nội dung Text
        /// </summary>
        public string TextBody { get; set; }

        /// <summary>
        /// Bcc
        /// </summary>
        public string BccEmailAddresses { get; set; }

        /// <summary>
        /// Độ ưu tiên (Enum: NotifyPriority)
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Delay thời gian gửi
        /// </summary>
        public int? DelayBeforeSend { get; set; }

        /// <summary>
        /// Đơn vị thời gian delay (Enum: MessageDelayPeriod - 0: giờ; 1: ngày)
        /// </summary>
        public int? MessageDelayPeriod { get; set; }

        /// <summary>
        /// Có tệp đính kèm
        /// </summary>
        public bool HasAttachments { get; set; }

        /// <summary>
        /// Kích hoạt
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// Thứ tự hiển thị
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Id SSO người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// UserName SSO người tạo
        /// </summary>
        public string CreatedByUserName { get; set; }

        /// <summary>
        /// Ngày giờ tạo
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Id SSO người sửa
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// UserName SSO người sửa
        /// </summary>
        public string UpdatedByUserName { get; set; }

        /// <summary>
        /// Ngày giờ sửa
        /// </summary>
        public DateTime? UpdatedOnUtc { get; set; }
    }
}