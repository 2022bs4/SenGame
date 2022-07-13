using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Interface;
using SqlModels.Data;
using SqlModels.Models;
using SqlModels.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SenGame.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IUserService _service;
        private readonly IConfiguration _config;
        private readonly SenGameContext _context;

        public UserController(IConfiguration config, IUserService service,UserManager<UserModel> user, SenGameContext context)
        {
            _userManager = user;
            _service = service;
            _config = config;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GameLibrary()
        {
            TempData["actiontype"] = "game";
            //UserModel LoginUser = await _userManager.GetUserAsync(HttpContext.User);
            //string UserId = LoginUser.Id;
            //var gamelist = _service.MyGameList(UserId);
            //var result = new GameLibraryViewModel()
            //{
            //    GameList = gamelist.Select(item => new GameLibraryViewModel.GameData
            //    {
            //        GameName = item.GameName,
            //        MediaUrl = item.MediaUrl,
            //    }).ToList()


            //};

            return View();
        }

        [HttpGet]
        public IActionResult User_information()
        {
            return View();
        }

        public IActionResult E1_User()
        {
            return View();
        }
        public IActionResult E2_UserPhoto()
        {
            return View();
        }
        public IActionResult E3_UserTopic()
        {
            return View();
        }

        public async Task<IActionResult> E4_UserPrivacy()
        {
            var privacymodel = new SqlModels.ViewModels.UserViewModels.PrivacieLibraryViewModel();
            return View(privacymodel);
        }

        public async Task<IActionResult> E4_UserPrivacyList()
        {
            var model = await _context.UserPrivacies.ToListAsync();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult E4_UserPrivacy(SqlModels.ViewModels.UserViewModels.PrivacieLibraryViewModel privacyVM)
        {
            TempData["actiontype"] = "privacy";

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
    }
}
