using AutoMapper;
using SampleNotify.Application.NotifyConfigGroups.Queries.GetAllNotifyConfigGroup;
using SampleNotify.Application.NotifyConfigGroups.Queries.GetListNotifyConfigGroup;
using SampleNotify.Application.NotifyConfigGroups.Queries.GetNotifyConfigGroup;
using SampleNotify.Models;
using SampleNotify.Models.Entity;
using Shared.Dto;

namespace SampleNotify.Application.AutoMappers
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<NotifyConfigGroup, NotifyConfigGroupDto>();
            CreateMap<NotifyConfigGroup, NotifyConfigGroupListDto>();
            CreateMap<NotifyConfigGroup, NotifyConfigGroupDetailDto>();
            CreateMap<QueryResult<NotifyConfigGroup>, QueryResult<NotifyConfigGroupListDto>>();
        }
    }
}