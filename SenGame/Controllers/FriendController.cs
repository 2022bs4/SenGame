using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlModels.FakeDate;
using SqlModels.Models;
using SqlModels.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SenGame.Controllers
{

    //[Authorize]
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
            //id = User.Identity.GetUserId();
            id = "1";
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

        List<UserBackground> userBackgrounds = new List<UserBackground>()
        {
            new UserBackground{ UserBackgroundId=1, BackgroundColor="linear-gradient(90deg, rgb(243, 243, 249), rgb(243, 243, 249))" }, //Original setting
            new UserBackground{ UserBackgroundId=2, BackgroundColor="linear-gradient(to top, #fbc2eb 0%, #a6c1ee 100%)" }, //Rainy Ashville
            new UserBackground{ UserBackgroundId=3, BackgroundColor="linear-gradient(120deg, #84fab0 0%, #8fd3f4 100%)" }, //Tempt Azure</
            new UserBackground{ UserBackgroundId=4, BackgroundColor="linear-gradient(120deg, #e0c3fc 0%, #8ec5fc 100%)" }, //Deep Blue
            new UserBackground{ UserBackgroundId=5, BackgroundColor="linear-gradient(to right, #fa709a 0%, #fee140 100%)" }, //True Sunset
            new UserBackground{ UserBackgroundId=6, BackgroundColor="linear-gradient(to top, #a8edea 0%, #fed6e3 100%)" }, 
            new UserBackground{ UserBackgroundId=7, BackgroundColor="linear-gradient(to top, #fddb92 0%, #d1fdff 100%)" }, 
            new UserBackground{ UserBackgroundId=8, BackgroundColor="linear-gradient(to right, #eea2a2 0%, #bbc1bf 19%, #57c6e1 42%, #b49fda 79%, #7ac5d8 100%)" },
        };
        public IActionResult Edit3_UserTopic()
        {
            return View();
        }

        //List<UserPrivacy> userprivacie = new List<UserPrivacy>()
        //{
        //    new UserPrivacy{UserPrivacyId=1, PrivacyState = "公開"},
        //    new UserPrivacy{UserPrivacyId=2, PrivacyState = "只限好友"},
        //    new UserPrivacy{UserPrivacyId=3, PrivacyState = "私人"}
        //};
        
        public IActionResult Edit4_UserPrivacy()
        {
            var model = new SqlModels.ViewModels.UserViewModels.PrivacieViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit4_UserPrivacy(SqlModels.ViewModels.UserViewModels.PrivacieViewModel privacyVM)
        {
            if (ModelState.IsValid)
            {
                //讀隱私代碼
                string privacyCode = privacyVM.Privacie;
                //由隱私代碼查詢名稱
                string privacy = privacyVM.Privacies.Where(c => c.Value == privacyCode)
                    .Select(x => x.Text).FirstOrDefault();

                return RedirectToAction("DisplayPrivacy", new { Privacy = privacy });
            }

            return View(privacyVM);
        }
        //顯示privacy資訊
        public IActionResult DisplayPrivacy(string privacy)
        {
            if (string.IsNullOrEmpty(privacy))
            {
                return Content("必須提供privacy參數!");
            }

            ViewData["Privacy"] = privacy;

            return View();
        }

        
        





        public IActionResult AddFriend()
        {
            return View();
        }
        public IActionResult WishList()
        {
            return View();
        }
    }
}
