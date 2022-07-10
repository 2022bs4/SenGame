using SqlModels.DTOModels;
using SqlModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface  IChatService:IBaseService
    {
        public List<GroupDTO> GetGroup();
        public List<UserModel> GetFriend();
    }
}
