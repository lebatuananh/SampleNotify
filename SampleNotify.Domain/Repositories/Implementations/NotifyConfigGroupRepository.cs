using SampleNotify.Models.Entity;
using SampleNotify.Models.Repositories.Interfaces;
using Shared.Infrastructure;

namespace SampleNotify.Models.Repositories.Implementations
{
    public class NotifyConfigGroupRepository : Repository<DataNotifyDbContext, NotifyConfigGroup>,
        INotifyConfigGroupRepository
    {
        public NotifyConfigGroupRepository(DataNotifyDbContext dbContext) : base(dbContext)
        {
        }
    }
}