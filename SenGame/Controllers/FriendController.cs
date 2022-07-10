
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using SqlModels.DTOModels;
using SqlModels.FakeDate;
using SqlModels.Models;
using SqlModels.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SqlModels.ViewModels.FriendViewModel;

namespace SenGame.Controllers
{

    [Authorize]
    public class FriendController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        public FriendController(UserManager<UserModel> usermodel)
        {
            _userManager = usermodel;
        }
        List<UserModel> user = new List<UserModel>()
        {
            new UserModel{Id="1",UserName="張學友",Account = "test123",PasswordHash="A!a123456",UserPicture="https://memeprod.ap-south-1.linodeobjects.com/user-gif-post/1653456571139.gif"},
            new UserModel{Id="2",UserName="金城武",Account = "test321",PasswordHash="A!a123456",UserPicture="https://memeprod.ap-south-1.linodeobjects.com/user-gif-post/1649456466797.gif"},
            new UserModel{Id="3",UserName="郭富城",Account = "test456",PasswordHash="A!a123456",UserPicture="https://memeprod.ap-south-1.linodeobjects.com/user-gif-thumbnail/7893d953a0c3fed57d6f8eaea1c064cf.gif"},
            new UserModel{Id="4",UserName="劉德華",Account = "test654",PasswordHash="A!a123456",UserPicture="https://j.gifs.com/5QX3NY.gif"},
            new UserModel{Id="5",UserName="劉",Account = "test654",PasswordHash="A!a123456",UserPicture="https://j.gifs.com/5QX3NY.gif"},

        };

        List<Usergroup> usergroup = new List<Usergroup>()
        {
            new Usergroup{UserGroupId=1,FriendGroupId=1,UserId="6158b61f-7504-4ecf-b61b-0535cb569079"},
            new Usergroup{UserGroupId=2,FriendGroupId=2,UserId="6158b61f-7504-4ecf-b61b-0535cb569079"},
            new Usergroup{UserGroupId=2,FriendGroupId=3,UserId="6158b61f-7504-4ecf-b61b-0535cb569079"},
            new Usergroup{UserGroupId=3,FriendGroupId=4,UserId="1"},

        };
        List<FriendGroup> friendgroup = new List<FriendGroup>()
        {
            new FriendGroup{FriendGoupId=1,GroupName="高中同學",UserId="1"},
            new FriendGroup{FriendGoupId=2,GroupName="我不知道",UserId="1"},
            new FriendGroup{FriendGoupId=3,GroupName="我不知道",UserId="3"},
            new FriendGroup{FriendGoupId=4,GroupName="我不知道",UserId="2"},
        };
        
      


        public IActionResult Index()
        {
            return View();
        }
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> Chat(string id)
        {
            ForumViewModel _fvm = new ForumViewModel();
           
            UserModel LoginUser = await _userManager.GetUserAsync(HttpContext.User);
           id = LoginUser.Id;

            //var theuser = from ug in usergroup
            //          where ug.UserId == id
            //          select ug.UserId;

            var theuser = usergroup.Where(ug => ug.UserId == id).Select(ug => ug.UserId);

            var gorups = from ug in usergroup
                        where ug.UserId == id
                        select ug.FriendGroupId;

            var result = new List<GroupDTO>();
            foreach (var item in gorups)
            {

                var groupname = from fg in friendgroup
                             where fg.FriendGoupId == item
                             select fg.GroupName;


                var friend = from fg in friendgroup
                             where fg.FriendGoupId == item
                             select fg.UserId;

                                 
                

            }



                    TempData["actiontype"] = "friend";












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
