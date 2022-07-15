using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
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

        public UserController(IUserService service,UserManager<UserModel> user)
        {
            _userManager = user;
            _service = service;
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
                MyFavourite = myfavouritegame.Select(item=>new GameLibraryViewModel.GameData
                {
                    GameName = item.GameName,
                    MediaUrl = item.MediaUrl,

                }).ToList()


            };
            

            return View(result);
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
