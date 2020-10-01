using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleNotify.Models.AggregateModels.NotifyConfigAggregate;
using SampleNotify.Models.AggregateModels.NotifyConfigGroupAggregate;

namespace SampleNotify.Infrastructure.EntityConfiguations
{
    public class NotifyConfigGroupConfiguration : IEntityTypeConfiguration<NotifyConfigGroup>
    {
        public void Configure(EntityTypeBuilder<NotifyConfigGroup> builder)
        {
            builder.ToTable("NOTIFY_CONFIG_GROUP");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.AppId)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}