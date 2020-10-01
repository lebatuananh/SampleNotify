using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleNotify.Models.AggregateModels.NotifyAggregate;

namespace SampleNotify.Infrastructure.EntityConfiguations
{
    public class NotifyConfiguration:IEntityTypeConfiguration<Notify>
    {
        public void Configure(EntityTypeBuilder<Notify> builder)
        {
            builder.ToTable("NOTIFY");
            builder.HasKey(e => e.Id);
        }
    }
}