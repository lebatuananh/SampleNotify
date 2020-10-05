using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleNotify.Models.Repositories.Interfaces;

namespace SampleNotify.Application.NotifyConfigGroups.Queries.GetAllNotifyConfigGroup
{
    public class GetAllNotifyConfigGroupQuery : IRequest<List<NotifyConfigGroupDto>>
    {
    }

    public class
        GetAllNotifyConfigGroupQueryHandler : IRequestHandler<GetAllNotifyConfigGroupQuery, List<NotifyConfigGroupDto>>
    {
        private readonly INotifyConfigGroupRepository _notifyConfigGroupRepository;

        public GetAllNotifyConfigGroupQueryHandler(INotifyConfigGroupRepository notifyConfigGroupRepository)
        {
            _notifyConfigGroupRepository = notifyConfigGroupRepository;
        }

        public async Task<List<NotifyConfigGroupDto>> Handle(GetAllNotifyConfigGroupQuery request,
            CancellationToken cancellationToken)
        {
            var result =
                await _notifyConfigGroupRepository.GetAsync(
                    x => new NotifyConfigGroupDto(x.Id, x.Title, x.Ord, x.AppId));
            return result.ToList();
        }
    }
}