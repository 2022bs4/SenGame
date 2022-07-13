using AutoMapper;
using SqlModels.DTOModels.Community;
using SqlModels.Models;
namespace Services.Mappings.ServiceMappings
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            #region -- Community --
            this.CreateMap<Forum, ForumDTO>().ForMember(x => x.Id, y => y.MapFrom(o => o.ForumId));
            #endregion
        }
    }
}
