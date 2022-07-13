
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.ChatService;
using Services.Interface;
using SqlModels.DTOModels;
using SqlModels.FakeDate;
using SqlModels.Models;
using SqlModels.ViewModels;
using System;
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
        private readonly FriendGroupService _service;
        
        public FriendController(UserManager<UserModel> usermodel, FriendGroupService service)
        {
            _userManager = usermodel;
            _service = service;
        }



        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Chat(string id)
        {

           
        UserModel LoginUser = await _userManager.GetUserAsync(HttpContext.User);
        id = LoginUser.Id;

         TempData["pic"] = LoginUser.UserPicture;


          TempData["actiontype"] = "friend";

            var groupname =  _service.GetGroup(id);
            var allfriend = _service.GetFriend(id);
            var result = new FriendViewModel()
            {
                Groups = groupname.Select(x=>new FriendViewModel.Group
                {
                    GroupName = x.GroupName,
                    Friends = allfriend.Select(y=>new FriendViewModel.Friend
                    {
                        Name = y.UserName,
                        Photo = y.UserPicture,
                        Id = y.UserId,
                    }).ToList()
               
                }).ToList(),
                
                

            };

            return View(result);
        }
        [HttpPost]
        public IActionResult Chat()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody]FriendViewModel group)
        {
            UserModel LoginUser = await _userManager.GetUserAsync(HttpContext.User);
            var userid = LoginUser.Id;
          
            for(int i = 0; i < group.GroupNames.Length; i++)
            {
                var x = new FriendGroup();
                x.GroupName = group.GroupNames[i];
                x.UserId = group.Ids[i];

                _service.Create<FriendGroup>(x);

            }
      
            
            return Ok();
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
