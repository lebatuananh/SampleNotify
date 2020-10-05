using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleNotify.Application.Models;
using SampleNotify.Application.Queries.NotifyConfigGroup;
using SampleNotify.Models.AggregateModels.NotifyConfigGroupAggregate;
using Shared.Dto;
using Shared.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace SampleNotify.Application.Read.NotifyConfigGroupQueryHandler
{
    public class
        GetListNotifyConfigGroupQueryHandler : IRequestHandler<GetListNotifyConfigGroupQuery,
            QueryResult<NotifyConfigGroupDto>>
    {
        private readonly INotifyConfigGroupRepository _notifyConfigGroupRepository;

        public GetListNotifyConfigGroupQueryHandler(INotifyConfigGroupRepository notifyConfigGroupRepository)
        {
            _notifyConfigGroupRepository = notifyConfigGroupRepository;
        }

        public async Task<QueryResult<NotifyConfigGroupDto>> Handle(GetListNotifyConfigGroupQuery request,
            CancellationToken cancellationToken)
        {
            var query = await
                _notifyConfigGroupRepository.QueryAsync(x =>
                        string.IsNullOrEmpty(request.Query) || EF.Functions.Like(x.Title, $"%{request.Query}%"),
                    request.Skip, request.Take);
            var result = query.To<QueryResult<NotifyConfigGroupDto>>();
            return result;
        }
    }
}