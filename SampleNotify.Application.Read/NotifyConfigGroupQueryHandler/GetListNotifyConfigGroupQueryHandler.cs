using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using SampleNotify.Application.Models;
using SampleNotify.Application.Queries.NotifyConfigGroup;
using Shared.Dto;

namespace SampleNotify.Application.Read.NotifyConfigGroupQueryHandler
{
    public class
        GetListNotifyConfigGroupQueryHandler : IRequestHandler<GetListNotifyConfigGroupQuery,
            QueryResult<NotifyConfigGroupDto>>
    {
        private readonly IDbConnection _dbConnection;

        public GetListNotifyConfigGroupQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<QueryResult<NotifyConfigGroupDto>> Handle(GetListNotifyConfigGroupQuery request,
            CancellationToken cancellationToken)
        {
            var builder = new SqlBuilder();
            var tmplQueryItems =
                builder.AddTemplate(
                    @"select * from NOTIFY_CONFIG_GROUP dcg /**where**/ order by dcg.Id  offset @Skip rows fetch next @Take row only");
            var tmplQueryCount = builder.AddTemplate(@"select count(dcg.id) from NOTIFY_CONFIG_GROUP dcg /**where**/");
            if (!string.IsNullOrEmpty(request.Query)) builder.Where(@"dcg.Title like concat('%', @Query, '%')");

            var queryStr = $@"{tmplQueryItems.RawSql};{tmplQueryCount.RawSql}";
            using var queryResult =
                await _dbConnection.QueryMultipleAsync(queryStr, new {request.Skip, request.Take, request.Query});
            var items = queryResult.Read<NotifyConfigGroupDto>();
            var count = queryResult.ReadFirst<int>();
            return new QueryResult<NotifyConfigGroupDto>(count, items);
        }
    }
}