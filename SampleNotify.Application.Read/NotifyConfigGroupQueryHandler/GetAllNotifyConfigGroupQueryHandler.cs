using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleNotify.Application.Models;
using SampleNotify.Application.Queries.NotifyConfigGroup;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace SampleNotify.Application.Read.NotifyConfigGroupQueryHandler
{
    public class
        GetAllNotifyConfigGroupQueryHandler : IRequestHandler<GetAllNotifyConfigGroupQuery, List<NotifyConfigGroupDto>>
    {
        private readonly IDbConnection _dbConnection;

        public GetAllNotifyConfigGroupQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<NotifyConfigGroupDto>> Handle(GetAllNotifyConfigGroupQuery request,
            CancellationToken cancellationToken)
        {
            var db = new QueryFactory(_dbConnection, new SqlServerCompiler());
            var query = db.Query("NOTIFY_CONFIG_GROUP").OrderBy("Ord");
            var result = await query.GetAsync<NotifyConfigGroupDto>();
            return result.ToList();
        }
    }
}