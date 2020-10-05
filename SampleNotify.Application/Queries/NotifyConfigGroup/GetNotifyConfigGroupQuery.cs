using MediatR;
using SampleNotify.Application.Models.NotifyConfigGroup;

namespace SampleNotify.Application.Queries.NotifyConfigGroup
{
    public class GetNotifyConfigGroupQuery : IRequest<NotifyConfigGroupDto>
    {
        public GetNotifyConfigGroupQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}