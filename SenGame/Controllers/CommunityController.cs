using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using SqlModels.Models;
using System;
using SqlModels.ViewModels;
using System.Collections.Generic;

namespace SenGame.Controllers
{
    public class CommunityController : Controller
    {

        private readonly ICommunityService _service;
        //private readonly IBaseService<Forum> _service;
        public CommunityController(ICommunityService service)
        {
            this._service = service;
        }
        //public CommunityController(IBaseService<Forum> service)
        //{
        //    //this._service = new GenericService<Forum>(context);
        //    this._service = service;

        //}
        public IActionResult Index()
        {
            var articles = _service.Article();
            var Articles = new List<CommunityViewModel>();
            foreach (var item in articles)
            {
                Articles.Add(new CommunityViewModel
                {
                    GameId = item.GameId,
                    GameName = item.GameName,
                    GameIntroduction = item.GameIntroduction,
                    MediaUrl = item.MediaUrl

                });
            }
            TempData["actiontype"] = "forum";
            return View(Articles);
        }
        public IActionResult ComomunityDynamicwall()
        {
            TempData["actiontype"] = "forum";
            return View();
        }

        [HttpGet]
        public IActionResult Swipers()
        {
            var img = _service.Swipers().ToArray();
            return Ok(img);
        }
        //顯示討論區
        public IActionResult Forum()
        {
            var forums = _service.GetAll();
            return View(forums);
        }
        //顯示使用者的討論區
        public IActionResult MyForum()
        {
            if (User.Identity.IsAuthenticated)
            {
                var forums = _service.GetUserForum(User.Identity.Name);
                return View(forums);
            }
            return Content("not login");
        }
    }
}
