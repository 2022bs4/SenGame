using System.Collections.Generic;
using System.Linq;
using SqlModels.Models;
using SqlModels.DTOModels;
using SqlModels.DTOModels.Community;


namespace Services.Interface
{
    public interface ICommunityService : IBaseService
    {
        //請打註解
        public List<Swipers> Swipers();
        //請打註解
        public List<CommunityDTO> Article();
        //取得所有的看板
        public List<ForumDTO> GetForums();
        //取得使用者的看板
        public List<ForumDTO> GetForums(string name);

    }
}
