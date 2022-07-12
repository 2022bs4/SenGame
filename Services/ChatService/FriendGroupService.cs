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
            foreach (var group in data)
            {
                result.Add(new FriendGroupDTO
                {
                    GroupName = group.GroupName,
                });
            }
            //foreach (var gid in groups)
            //{
            //    var groupname = Repository.GetAll<FriendGroup>().Where(x=>x.FriendGroupId == gid).Select(x => x.GroupName).Distinct();

            //    foreach(var item in groupname)
            //    {

            //        result.Add(new FriendGroupDTO
            //        {
            //            GroupName = item,
            //        });
   
            //    }
            //}
            return result;

        }
        public List<FriendGroupDTO> GetFriend(string id)
        {

            var TheUser = Repository.FindBy<UserModel>(x => x.Id == id).FirstOrDefault();

            var groups = Repository.GetAll<Usergroup>().Where(x => x.UserId == TheUser.Id).Select(x => x.FriendGroupId);
            
            
            var result = new List<FriendGroupDTO>();
            foreach (var gid in groups)
            {
                var groupname = Repository.GetAll<FriendGroup>().Where(x => x.FriendGroupId == gid).Select(x=>x.UserId);
                foreach (var item in groupname)
                {
                    var friends = Repository.FindBy<UserModel>(x => x.Id == item).Select(y => new { y.UserName, y.UserPicture,y.Id});
                    foreach(var friend in friends)
                    {
                        result.Add(new FriendGroupDTO
                        {
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
