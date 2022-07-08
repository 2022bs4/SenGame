using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlModels.Models;
using SqlModels.DTOModels;


namespace Services.Interface
{
    public interface ICommunityService : IBaseService
    {
        //請打註解
        public List<Swipers> Swipers();
        //請打註解
        public List<CommunityDTO> Article();
        //查詢使用者的討論區
        public IQueryable<Forum> GetUserForum(string name);

    }
}
