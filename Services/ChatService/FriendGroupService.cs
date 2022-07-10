using Services.Interface;
using SqlModels.DTOModels;
using SqlModels.Models;
using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ChatService
{
    public class FriendGroupService : BaseService, IChatService
    {
        public FriendGroupService(IRepository repository) : base(repository)
        {
        }

        public List<UserModel> GetFriend()
        {
            throw new NotImplementedException();
        }

        public List<GroupDTO> GetGroup()
        {
            throw new NotImplementedException();
        }
    }
}
