using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SenGame.Controllers
{
    //[Authorize]
    public class FriendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //[Authorize]
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
