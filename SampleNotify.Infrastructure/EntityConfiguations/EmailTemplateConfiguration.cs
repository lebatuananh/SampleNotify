using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleNotify.Models.AggregateModels.EmailTemplateAggregate;

namespace SampleNotify.Infrastructure.EntityConfiguations
{
    public class EmailTemplateConfiguration:IEntityTypeConfiguration<EmailTemplate>
    {
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.ToTable("EMAILTEMPLATE");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

            builder.Property(e => e.AppId)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.Property(e => e.AppNotifyConfigCode)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.Property(e => e.BccEmailAddresses)
                    .HasMaxLength(1000);

            builder.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

            builder.Property(e => e.CreatedByUserName)
                    .IsRequired()
                    .HasMaxLength(256);

            builder.Property(e => e.CreatedOnUtc)
                    .HasColumnType("datetime");

            builder.Property(e => e.DelayBeforeSend);

            builder.Property(e => e.Description)
                    .HasMaxLength(4000);

            builder.Property(e => e.DisplayOrder)
                    .HasDefaultValueSql("((9999))");

            builder.Property(e => e.GroupType);

            builder.Property(e => e.HasAttachments);

            builder.Property(e => e.HtmlBody);

            builder.Property(e => e.LanguageCulture)
                    .HasMaxLength(50);

            builder.Property(e => e.MessageDelayPeriod);

            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.Property(e => e.Priority);

            builder.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.Property(e => e.TextBody);

            builder.Property(e => e.UpdatedBy)
                    .HasMaxLength(450);

            builder.Property(e => e.UpdatedByUserName)
                    .HasMaxLength(256);

            builder.Property(e => e.UpdatedOnUtc)
                    .HasColumnType("datetime");
        }
    }
}