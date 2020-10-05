using AutoMapper;
using SampleNotify.Application.Models.NotifyConfigGroup;
using SampleNotify.Models.Entity;
using Shared.Dto;

namespace SampleNotify.Application.AutoMappers
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<NotifyConfigGroup, NotifyConfigGroupDto>();
            CreateMap<QueryResult<NotifyConfigGroup>, QueryResult<NotifyConfigGroupDto>>();
        }
    }
}