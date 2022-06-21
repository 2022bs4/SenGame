using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SenGame.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Chat()
        {
            return View();
        }
        public IActionResult member__information()
        {
            return View();
        }

        public IActionResult a1_Edit_Member()
        {
            return View();
        }

        public IActionResult a2_Edit_MemberPhoto()
        {
            return View();
        }

        public IActionResult a3_Edit_MemberTopic()
        {
            return View();
        }

        public IActionResult a4_Edit_MemberPrivacy()
        {
            return View();
        }

        public IActionResult AddFriend()
        {
            return View();
        }
    }
}
