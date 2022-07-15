using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Interface;
using SqlModels.Data;
using SqlModels.Models;
using SqlModels.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using static SqlModels.ViewModels.GameLibraryViewModel;

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

        
        [Authorize]
        public async Task<IActionResult> GameLibrary()
        {
            TempData["actiontype"] = "game";
            UserModel LoginUser = await _userManager.GetUserAsync(HttpContext.User);
            string UserId = LoginUser.Id;
            //_service.MyGameList(UserId)=>gamelist
            var uncategorizedGame = _service.UncategorizedGame(UserId).gamelist;
            var myfavouritegame = _service.MyFavouritrGame(UserId).myfavourite;

            var result = new GameLibraryViewModel()
            {

                GameList = uncategorizedGame.Select(item => new GameLibraryViewModel.GameData
                {
                    GameName = item.GameName,
                    MediaUrl = item.MediaUrl,
                }).ToList(),
                MyFavourite = myfavouritegame.Select(item => new GameLibraryViewModel.GameData
                {
                    GameName = item.GameName,
                    MediaUrl = item.MediaUrl,

                }).ToList()
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

            };
            //};

            return View(result);
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

        public IActionResult E4_UserPrivacy()
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

        [HttpPost]
        public IActionResult _GameDetailPartial([FromBody] Game_Name name)
        {

           
            //try
            //{
            //    var GameName = name.GameName;
            //    var gamedetail = _service.MyGameDetail(GameName).GetGameDetails;
            //    var result = new GameLibraryViewModel()
            //    {
            //        GetGameDetails = gamedetail.Select(item => new GameLibraryViewModel.GameDetail
            //        {
            //            GameIntroduction = item.GameIntroduction,
            //            MediaUrl = item.MediaUrl,
            //            ReleaseTime = item.ReleaseTime,
            //            Developer = item.Developer

            //        }).ToList()
            //    };
            //    return PartialView(result);
            //}
            //catch(Exception ex)
            //{
            //    return Content("null");
            //}
            try
            {
                var GameName = name.GameName;
                var gamedetail = _service.MyGameDetail(GameName).GetGameDetails;
                var result = new GameLibraryViewModel()
                {
                    GetGameDetails = gamedetail.Select(item => new GameLibraryViewModel.GameDetail
                    {
                        GameIntroduction = item.GameIntroduction,
                        MediaUrl = item.MediaUrl,
                        ReleaseTime = item.ReleaseTime,
                        Developer = item.Developer

                    }).ToList()
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                return Content("null");
            }


        }

    }
}
