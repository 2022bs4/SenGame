using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class FriendGroupService : BaseService
    {
        public FriendGroupService(IRepository repository) : base(repository)
        {

        }
        public List<FriendGroupDTO> GetGroup(string id)
        {    //取得當前使用者ID        
            var TheUser = Repository.FindBy<UserModel>(x => x.Id == id).FirstOrDefault();

            //取得使用者所擁有的群組
            var groups = Repository.GetAll<Usergroup>().Where(x => x.UserId == TheUser.Id);

            var name = Repository.GetAll<FriendGroup>();

            var data = name.Join(groups, s => s.FriendGroupId, x => x.FriendGroupId, (s, x) => new { s.GroupName }).Distinct();

            var result = new List<FriendGroupDTO>();

            foreach (var friend in data)
            {
                result.Add(new FriendGroupDTO
                {
                    GroupName = friend.GroupName,

                });
            }


            return result;
        }
        public List<FriendGroupDTO> GetFriend(string id)
        {

            var TheUser = Repository.FindBy<UserModel>(x => x.Id == id).FirstOrDefault();

            var groups = Repository.GetAll<Usergroup>().Where(x => x.UserId == TheUser.Id).Select(x => x.FriendGroupId);


            var result = new List<FriendGroupDTO>();
            foreach (var gid in groups)
            {
                var groupname = Repository.GetAll<FriendGroup>().Where(x => x.FriendGroupId == gid);
                foreach (var item in groupname)
                {
                    var friends = Repository.GetAll<UserModel>().Where(x => x.Id == item.UserId);
                    foreach (var friend in friends)
                    {
                        result.Add(new FriendGroupDTO
                        {
                            GroupName = item.GroupName,
                            UserName = friend.UserName,
                            UserPicture = friend.UserPicture,
                            UserId = friend.Id,
                        });
                    }
                }
            }
            return result;
        }


    }

}
