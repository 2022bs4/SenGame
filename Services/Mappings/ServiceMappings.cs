using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlModels.Models;

namespace Services.Mappings
{
    public class ServiceMappings:Profile
    {
        public ServiceMappings()
        {
            //CreateMap<Card, CardViewModel>()
            //    .ForMember(x => x.Id, y => y.MapFrom(o => o.CardId))
            //    .ForMember(x => x.Name, y => y.MapFrom(o => $"{o.Id}: {o.Name}"))
            //    .ForMember(x => x.ImgUri, y => y.AllowNull())
            //    .ReverseMap();

            // ...其他的對映內容 (使用 CreateMap<> 建立下一組)
        }
    }
}
