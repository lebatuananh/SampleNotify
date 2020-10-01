using System.Data;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleNotify.Application.Models;
using SampleNotify.Application.Queries.NotifyConfigGroup;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace SampleNotify.Application.Read.NotifyConfigGroupQueryHandler
{
    public class GetNotifyConfigGroupQueryHandler : IRequestHandler<GetNotifyConfigGroupQuery, NotifyConfigGroupDto>
    {
        private readonly IDbConnection _dbConnection;

        public GetNotifyConfigGroupQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<NotifyConfigGroupDto> Handle(GetNotifyConfigGroupQuery request,
            CancellationToken cancellationToken)
        {
            var db = new QueryFactory(_dbConnection, new SqlServerCompiler());
            var query = db.Query("NOTIFY_CONFIG_GROUP").Where("Id", "=", request.Id);
            var result = await query.FirstOrDefaultAsync<NotifyConfigGroupDto>();
            return result;
        }
    }
}