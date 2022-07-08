using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlModels.FakeDate;
using SqlModels.Models;
using SqlModels.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SenGame.Controllers
{

    [Authorize]
    public class FriendController : Controller
    {
        List<UserModel> user = new List<UserModel>()
        {
            new UserModel{Id="1",UserName="張學友",Account = "test123",PasswordHash="A!a123456",UserPicture="https://memeprod.ap-south-1.linodeobjects.com/user-gif-post/1653456571139.gif"},
            new UserModel{Id="2",UserName="金城武",Account = "test321",PasswordHash="A!a123456",UserPicture="https://memeprod.ap-south-1.linodeobjects.com/user-gif-post/1649456466797.gif"},
            new UserModel{Id="3",UserName="郭富城",Account = "test456",PasswordHash="A!a123456",UserPicture="https://memeprod.ap-south-1.linodeobjects.com/user-gif-thumbnail/7893d953a0c3fed57d6f8eaea1c064cf.gif"},
            new UserModel{Id="4",UserName="劉德華",Account = "test654",PasswordHash="A!a123456",UserPicture="https://j.gifs.com/5QX3NY.gif"},

        };
        List<Usergroup> usergroup = new List<Usergroup>()
        {
            new Usergroup{UserGroupId=1,FriendGroupId=1,UserId="1"},
            new Usergroup{UserGroupId=2,FriendGroupId=1,UserId="2"},
            new Usergroup{UserGroupId=3,FriendGroupId=1,UserId="3"},
            new Usergroup{UserGroupId=4,FriendGroupId=1,UserId="4"},
        };
        List<FriendGroup> friendgroup = new List<FriendGroup>()
        {
            new FriendGroup{FriendGoupId=1,GroupName="高中同學"},
        };

        
      
        public IActionResult Index()
        {
            return View();
        }
        //[Authorize]
        [HttpGet]
        public IActionResult Chat(string id)
        {
            id = User.Identity.GetUserId();
            var TheUser = from u in user
                       join ug in usergroup on u.Id equals ug.UserId
                       join fg in friendgroup on ug.FriendGroupId equals fg.FriendGoupId
                       where u.Id != id
                       group u by fg.GroupName into allgroup
                       select allgroup;
            

       



            return View();
        }
        [HttpPost]
        public IActionResult Chat()
        {
            return View();
        }
        public IActionResult User__information()
        {
            return View();
        }

        public IActionResult Edit1_User()
        {
            return View();
        }

        public IActionResult Edit2_UserPhoto()
        {
            return View();
        }

        public IActionResult Edit3_UserTopic()
        {
            return View();
        }

        public IActionResult Edit4_UserPrivacy()
        {
            return View();
        }

        public IActionResult AddFriend()
        {
            return View();
        }
    }
}
