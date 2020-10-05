using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleNotify.Models.Repositories.Interfaces;
using Shared.Extensions;

namespace SampleNotify.Application.NotifyConfigGroups.Queries.GetNotifyConfigGroup
{
    public class GetNotifyConfigGroupQuery : IRequest<NotifyConfigGroupDetailDto>
    {
        public GetNotifyConfigGroupQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class
        GetNotifyConfigGroupQueryHandler : IRequestHandler<GetNotifyConfigGroupQuery, NotifyConfigGroupDetailDto>
    {
        private readonly INotifyConfigGroupRepository _configGroupRepository;

        public GetNotifyConfigGroupQueryHandler(INotifyConfigGroupRepository configGroupRepository)
        {
            _configGroupRepository = configGroupRepository;
        }

        public async Task<NotifyConfigGroupDetailDto> Handle(GetNotifyConfigGroupQuery request,
            CancellationToken cancellationToken)
        {
            var query = await _configGroupRepository.GetByIdAsync(request.Id);
            var result = query.To<NotifyConfigGroupDetailDto>();
            return result;
        }
    }
}