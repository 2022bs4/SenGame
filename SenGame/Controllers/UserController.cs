using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
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

        public UserController(IUserService service,UserManager<UserModel> user)
        {
            _userManager = user;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GameLibrary()
        {
            TempData["actiontype"] = "game";
            UserModel LoginUser = await _userManager.GetUserAsync(HttpContext.User);
            string UserId = LoginUser.Id;
            var gamelist = _service.MyGameList(UserId);
            var result = new GameLibraryViewModel()
            {
                GameList = gamelist.Select(item => new GameLibraryViewModel.GameData
                {
                    GameName = item.GameName,
                    MediaUrl = item.MediaUrl,
                }).ToList()


            };

            return View(result);
        }
    }
}
