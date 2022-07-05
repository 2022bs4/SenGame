using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlModels.Models;
using SqlModels.DTOModels;


namespace Services.Interface
{
    public interface ICommunityService : IBaseService<Forum>
    {
        List<Swipers> Swipers();
        List<CommunityDTO> Article();
        //查詢使用者的討論區
        public IEnumerable<Forum> GetUserForum(string name);

    }
}
