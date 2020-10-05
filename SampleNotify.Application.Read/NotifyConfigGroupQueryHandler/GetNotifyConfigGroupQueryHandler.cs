using MediatR;
using SampleNotify.Application.Models;
using SampleNotify.Application.Queries.NotifyConfigGroup;
using SampleNotify.Models.AggregateModels.NotifyConfigGroupAggregate;
using Shared.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace SampleNotify.Application.Read.NotifyConfigGroupQueryHandler
{
    public class GetNotifyConfigGroupQueryHandler : IRequestHandler<GetNotifyConfigGroupQuery, NotifyConfigGroupDto>
    {
        private readonly INotifyConfigGroupRepository _configGroupRepository;

        public GetNotifyConfigGroupQueryHandler(INotifyConfigGroupRepository configGroupRepository)
        {
            _configGroupRepository = configGroupRepository;
        }

        public async Task<NotifyConfigGroupDto> Handle(GetNotifyConfigGroupQuery request,
            CancellationToken cancellationToken)
        {
            var query = await _configGroupRepository.GetByIdAsync(request.Id);
            var result = query.To<NotifyConfigGroupDto>();
            return result;
        }
    }
}