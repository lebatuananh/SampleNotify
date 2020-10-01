using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleNotify.Models.AggregateModels.CustomerNotifyConfigAggregate;

namespace SampleNotify.Infrastructure.EntityConfiguations
{
    public class CustomerNotifyConfigConfiguration : IEntityTypeConfiguration<CustomerNotifyConfig>
    {
        public void Configure(EntityTypeBuilder<CustomerNotifyConfig> builder)
        {
            builder.ToTable("CUSTOMER_NOTIFY_CONFIG");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.AccountId)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.AppId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(e => e.NotifyConfigCode)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}