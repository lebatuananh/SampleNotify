using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SampleNotify.Models.AggregateModels.CustomerNotifyConfigAggregate;
using SampleNotify.Models.AggregateModels.EmailTemplateAggregate;
using SampleNotify.Models.AggregateModels.NotifyAggregate;
using SampleNotify.Models.AggregateModels.NotifyConfigAggregate;
using SampleNotify.Models.AggregateModels.NotifyConfigGroupAggregate;

namespace SampleNotify.Infrastructure
{
    public class DataNotifyDbContext : DbContext
    {
        public DataNotifyDbContext()
        {
        }

        public DataNotifyDbContext(DbContextOptions<DataNotifyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NotifyConfig> NotifyConfig { get; set; }
        public virtual DbSet<NotifyConfigGroup> NotifyConfigGroup { get; set; }
        public virtual DbSet<EmailTemplate> Emailtemplate { get; set; }
        public virtual DbSet<CustomerNotifyConfig> CustomerNotifyConfig { get; set; }
        public virtual DbSet<Notify> Notifies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}