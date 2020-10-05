using AutoMapper;
using SampleNotify.Application.Commands.NotifyConfigGroups;
using SampleNotify.Models.Entity;

namespace SampleNotify.Application.AutoMappers
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<AddNotifyConfigGroupCommand, NotifyConfigGroup>()
                .ConstructUsing(c => new NotifyConfigGroup(c.Title, c.Ord, c.AppId));
            CreateMap<UpdateNotifyConfigGroupCommand, NotifyConfigGroup>();
        }
    }
}