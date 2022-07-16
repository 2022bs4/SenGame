using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Interface;
using SqlModels.Data;
using SqlModels.DTOModels;
using SqlModels.Models;
using SqlModels.ViewModels;
using SqlModels.ViewModels.UserViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using static SqlModels.ViewModels.GameLibraryViewModel;
using Microsoft.AspNetCore.Identity;


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

        //-------------------------從這裡開始是 明翰 的OOOOOOOOOOOOO-----------------------------------
        
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

        [HttpPost]
        public IActionResult _GameDetailPartial([FromBody] Game_Name name)
        {

            #region
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
            #endregion
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
                        Developer = item.Developer,
                        Marker = item.Marker,
                        GameSwipers = item.GameSwipers.Select(img => new GameDetail.GameSwiper
                        {
                            MediaUrl = img.MediaUrl
                        }).ToList(),

                    }).ToList()
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                return Content("null");
            }






        }
        //-------------------------從這裡結束是 明翰 的OOOOOOOOOOOOO-----------------------------------


        //-------------------------從這裡開始是 璇   的OOOOOOOOOOOOO-----------------------------------
        [HttpGet]
        public IActionResult User_information()
        {
            return View();
        }
        [HttpGet]
        public IActionResult E1_User()
        {
            var editusermodel = new SqlModels.ViewModels.UserViewModels.EditUserLibraryViewModel();
            return View(editusermodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult E1_User(SqlModels.ViewModels.UserViewModels.EditUserLibraryViewModel edituserVM)
        {
            TempData["actiontype"] = "edituser";

            if (ModelState.IsValid)
            {
                //讀編輯國家代碼
                string edituserCode = edituserVM.UserCountry;
                //由隱私代碼查詢名稱
                string edituser = edituserVM.UserCountryies.Where(e => e.Value == edituserCode)
                    .Select(x => x.Text).FirstOrDefault();

                return RedirectToAction("DisplayEditUser", new { EditUser = edituser });
            }

            return View(edituserVM);
        }
        //顯示edituser資訊
        public IActionResult DisplayEditUser(string edituser)
        {
            if (string.IsNullOrEmpty(edituser))
            {
                return Content("必須提供privacy參數!");
            }

            ViewData["EditUser"] = edituser;

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
            var privacymodel = new PrivacieLibraryViewModel();
            return View(privacymodel);
        }

        //public async Task<IActionResult> E4_UserPrivacyList()
        //{
        //    var model = await _context.UserPrivacies.ToListAsync();
        //    return View(model);
        //}



        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Post_E4_UserPrivacy([FromBody]OutputUserDTO model)
        {
            //抓登入使用者的id
            //var userId = GetUserId();
            string userId = "4c01f614-06bf-4fd6-897a-a62a0af4b64c";
            var id = model.UserPrivacyId;
            var result = _service.test(userId , id);



            TempData["actiontype"] = "privacy";

            //if (ModelState.IsValid)
            //{
            //    //讀隱私代碼
            //    string privacyCode = privacyVM.Privacie;
            //    //由隱私代碼查詢名稱
            //    string privacy = privacyVM.Privacies.Where(c => c.Value == privacyCode)
            //        .Select(x => x.Text).FirstOrDefault();

            //    return RedirectToAction("DisplayPrivacy", new { Privacy = privacy });
            //}
            //下斷點
            return Ok();
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

        //public async Task<string> GetUserId()
        //{
        //    //UserModel user = await _manger.GetUserAsync(HttpContext.User);
        //    //var userId = user.Id;
        //    //return userId;
        //}
        //-------------------------從這裡結束是 璇   的OOOOOOOOOOOOO-----------------------------------






        //-------------------------從這裡開始是 君君   的OOOOOOOOOOOOO-----------------------------------
        public IActionResult WishList(int id)
        {
            var wishes = _service.FindBy<Wish>(m => m.WishId == id);
            return View(wishes);
        }

        //-------------------------從這裡結束是 君君   的OOOOOOOOOOOOO-----------------------------------
    }
}
