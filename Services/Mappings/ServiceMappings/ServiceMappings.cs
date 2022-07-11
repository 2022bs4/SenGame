using AutoMapper;
using SqlModels.DTOModels.Community;
using SqlModels.Models;
namespace Services.Mappings.ServiceMappings
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            this.CreateMap<Forum, ForumDTO>().ForMember(x => x.Id, y => y.MapFrom(o => o.ForumId));
            //.ForMember(x => x.Name, y => y.MapFrom(o => o.Name))
            //.ForMember(x => x.Banner, y => y.MapFrom(o => o.Banner));

        }
    }
}
