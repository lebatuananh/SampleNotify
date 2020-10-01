using SampleNotify.Models.AggregateModels.NotifyConfigGroupAggregate;
using Shared.Infrastructure;

namespace SampleNotify.Infrastructure.Repositories
{
    public class NotifyConfigGroupRepository : Repository<DataNotifyDbContext, NotifyConfigGroup>,
        INotifyConfigGroupRepository
    {
        public NotifyConfigGroupRepository(DataNotifyDbContext dbContext) : base(dbContext)
        {
        }
    }
}