using MediatR;
using SampleNotify.Application.Models;

namespace SampleNotify.Application.Queries.NotifyConfigGroup
{
    public class GetNotifyConfigGroupQuery : IRequest<NotifyConfigGroupDto>
    {
        public int Id { get; set; }

        public GetNotifyConfigGroupQuery(int id)
        {
            Id = id;
        }
    }
}