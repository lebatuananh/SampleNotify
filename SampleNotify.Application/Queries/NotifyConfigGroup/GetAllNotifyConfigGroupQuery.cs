using System.Collections.Generic;
using MediatR;
using SampleNotify.Application.Models.NotifyConfigGroup;

namespace SampleNotify.Application.Queries.NotifyConfigGroup
{
    public class GetAllNotifyConfigGroupQuery : IRequest<List<NotifyConfigGroupDto>>
    {
    }
}