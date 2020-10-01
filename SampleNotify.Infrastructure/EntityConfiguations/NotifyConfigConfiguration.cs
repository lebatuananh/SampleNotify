using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleNotify.Models.AggregateModels.NotifyConfigAggregate;

namespace SampleNotify.Infrastructure.EntityConfiguations
{
    public class NotifyConfigConfiguration : IEntityTypeConfiguration<NotifyConfig>
    {
        public void Configure(EntityTypeBuilder<NotifyConfig> builder)
        {
            builder.ToTable("NOTIFY_CONFIG");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Description).HasMaxLength(4000);

            builder.Property(e => e.GroupId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasKey(e => e.Id);

            builder.HasOne(d => d.Group)
                .WithMany(p => p.NotifyConfig)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NOTIFY_CONFIG_NOTIFY_CONFIG_GROUP");
        }
    }
}