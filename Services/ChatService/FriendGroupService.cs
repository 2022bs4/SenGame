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
        public List<FriendGroupDTO> GetGroupName(string id)
        {      
            
            //取得使用者所擁有的群組         
            var groups = Repository.GetAll<Usergroup>().Where(x => x.UserId == id);

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
            var groups = Repository.GetAll<Usergroup>().Where(x => x.UserId == id).Select(x => x.FriendGroupId);


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
        public List<FriendGroupDTO> GetChatContent(string id)
        {
            var chats = Repository.GetAll<Chat>().Where(x => x.UserId == id).Select(x=>x.FriendChatId);
            var result = new List<FriendGroupDTO>();
            foreach(var chat in chats)
            {
                var contents = Repository.GetAll<FriendChat>().Where(x => x.FriendChatId == chat).Select(x => new { x.UserId, x.ChatContent, x.ChatTime, x.PictureFile });
                foreach(var content in contents) 
                {
                    
                    result.Add(new FriendGroupDTO
                    {
                        UserId = content.UserId,
                        ChatContent = content.ChatContent,
                        PictureFile = content.PictureFile,
                        ChatTime = content.ChatTime,
                        
                    }); 
                }
            }
            return result;
        }
        public List<FriendGroupDTO> GetAllGroup(string groupname)
        {
            var group = Repository.GetAll<FriendGroup>().Where(x => x.GroupName == groupname).Select(x => new { x.FriendGroupId, x.UserId, x.GroupName });
            var friend = group.Join(Repository.GetAll<Usergroup>(), s => s.FriendGroupId, x => x.FriendGroupId, (s, x) => new { s.FriendGroupId, s.GroupName, x.UserGroupId, s.UserId });
            var result = new List<FriendGroupDTO>();
            foreach(var item in friend)
            {
                result.Add(new FriendGroupDTO
                {
                    FriendGroupId = item.FriendGroupId,
                    UserGroupId = item.UserGroupId,
                    UserId = item.UserId,
                    GroupName = item.GroupName,
                });
            }
            return result;
        }


    }


}
