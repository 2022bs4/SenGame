
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

    //[Authorize]
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



            var groupname =  _service.GetGroup(id);
            var allfriend = _service.GetFriend(id);
          
            var result = new FriendViewModel()
            {
                Groups = groupname.Select(x => new FriendViewModel.Group
                {
                    GroupName = x.GroupName,
                    Friends = allfriend.Select(y => new FriendViewModel.Friend
                    {
                        GroupName = y.GroupName,
                        Name = y.UserName,
                        Photo = y.UserPicture,
                        Id = y.UserId,
                    }).ToList()

                }).ToList(),
            };


            TempData["actiontype"] = "friend";


            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] FriendViewModel group)
        {
            UserModel LoginUser = await _userManager.GetUserAsync(HttpContext.User);
            var userid = LoginUser.Id;

            for (int i = 0; i < group.GroupNames.Length; i++)
            {
                var friendgroup = new FriendGroup();
                friendgroup.GroupName = group.GroupNames[i];
                friendgroup.UserId = group.Ids[i];
                _service.Create<FriendGroup>(friendgroup);

                var usergroup = new Usergroup();
                usergroup.UserId = userid;
                usergroup.FriendGroupId = friendgroup.FriendGroupId;
                _service.Create<Usergroup>(usergroup);
            }


            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> PostFriendId([FromBody]FriendViewModel friendid)
        {
            UserModel LoginUser = await _userManager.GetUserAsync(HttpContext.User);
            var  id = LoginUser.Id;
            var result = _service.GetChatContent(id);
           
            return RedirectToAction("ReadChatContent", result);
        }
        [HttpGet]
        public async Task<IActionResult> ReadChatContent(string id)
        {
            UserModel LoginUser = await _userManager.GetUserAsync(HttpContext.User);
             id = LoginUser.Id;
            var result = _service.GetChatContent(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChatContext([FromBody]FriendViewModel context)
        {
            UserModel LoginUser = await _userManager.GetUserAsync(HttpContext.User);
            var userid = LoginUser.Id;

            FriendChat fc = new FriendChat();
            fc.ChatContent = context.ChatContent;
            fc.UserId = context.UserId;
            var chattime = DateTime.Now;
            fc.ChatTime = chattime;
            _service.Create<FriendChat>(fc);

            Chat chat = new Chat();
            chat.FriendChatId = fc.FriendChatId;
            chat.UserId = userid;
            _service.Create<Chat>(chat);

            return Ok();
        }
        public async Task<IActionResult> DeleteGroup([FromBody] FriendViewModel context)
        {
            UserModel LoginUser = await _userManager.GetUserAsync(HttpContext.User);
            var userid = LoginUser.Id;
            var friend = _service.DeleteGroup(context.Groupname);
           foreach(var item in friend)
            {
             var fg = new FriendGroup();
                fg.FriendGroupId = item.FriendGroupId;
                fg.GroupName = item.GroupName;
                fg.UserId = item.UserId;

                var ug = new Usergroup();
                ug.UserGroupId = item.UserGroupId;
                ug.UserId = userid;
                ug.FriendGroupId = fg.FriendGroupId;

                 _service.Delete<Usergroup>(ug);
                 _service.Delete<FriendGroup>(fg);                   

            }


            return Ok();
        }

        public IActionResult User__information()
        {
            return View();
        }
        public IActionResult AddFriend()
        {
            return View();
        }
        public IActionResult PendingInvites()
        {
            return View();
        }
        public IActionResult Groups()
        {
            return View();
        }
        public IActionResult PendingInvitesGroups()
        {
            return View();
        }
        public IActionResult FindGroup()
        {
            return View();
        }        
        public IActionResult GroupCreate()
        {
            return View();
        }
    }
}
