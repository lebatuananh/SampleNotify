using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleNotify.Application.Queries;
using SampleNotify.Models.Repositories.Interfaces;
using Shared.BaseModel;
using Shared.Dto;
using Shared.Extensions;

namespace SampleNotify.Application.NotifyConfigGroups.Queries.GetListNotifyConfigGroup
{
    public class GetListNotifyConfigGroupQuery : ListQuery, IRequest<PagingResponse<IList<NotifyConfigGroupListDto>>>
    {
        public GetListNotifyConfigGroupQuery(int pageIndex, int pageSize, string query = null, string sorts = null) :
            base(pageIndex,
                pageSize, query, sorts)
        {
        }
    }

    public class
        GetListNotifyConfigGroupQueryHandler : IRequestHandler<GetListNotifyConfigGroupQuery,
            PagingResponse<IList<NotifyConfigGroupListDto>>>
    {
        private readonly INotifyConfigGroupRepository _notifyConfigGroupRepository;

        public GetListNotifyConfigGroupQueryHandler(INotifyConfigGroupRepository notifyConfigGroupRepository)
        {
            _notifyConfigGroupRepository = notifyConfigGroupRepository;
        }

        public async Task<PagingResponse<IList<NotifyConfigGroupListDto>>> Handle(GetListNotifyConfigGroupQuery request,
            CancellationToken cancellationToken)
        {
            var query = await
                _notifyConfigGroupRepository.QueryAsync(x =>
                        string.IsNullOrEmpty(request.Query) || EF.Functions.Like(x.Title, $"%{request.Query}%"),
                    request.PageIndex, request.PageSize, request.Sorts);
            var result = query.To<QueryResult<NotifyConfigGroupListDto>>();
            var response = new PagingResponse<IList<NotifyConfigGroupListDto>>(true, null)
            {
                Data = result.Items.ToList(),
                Total = result.Count,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return response;
        }
    }
}