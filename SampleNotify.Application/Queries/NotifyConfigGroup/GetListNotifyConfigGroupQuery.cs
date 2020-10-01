using MediatR;
using SampleNotify.Application.Models;
using Shared.Dto;

namespace SampleNotify.Application.Queries.NotifyConfigGroup
{
    public class GetListNotifyConfigGroupQuery : ListQuery, IRequest<QueryResult<NotifyConfigGroupDto>>
    {
        public GetListNotifyConfigGroupQuery(int skip, int take, string query = null) : base(skip, take, query)
        {
        }
    }
}