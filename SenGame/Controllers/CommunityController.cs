using Microsoft.AspNetCore.Mvc;
using System;
using Services;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Services.Interface;
using SqlModels.Models;
using SqlModels.ViewModels;
using SqlModels.ViewModels.Community;

namespace SenGame.Controllers
{
    public class CommunityController : Controller
    {

        private readonly ICommunityService _service;
        
        public CommunityController(ICommunityService service)
        {
       
            this._service = service;
        }

        public IActionResult Index()
        {
            var articles = _service.Article();

            var result = new CommunityIndexViewModel()
            {
                GameList = articles.Select(item => 
                new CommunityIndexViewModel.GameData
                {
                    GameId = item.GameId,
                    GameName = item.GameName,
                    GameIntroduction = item.GameIntroduction,
                    MediaUrl = item.MediaUrl
                }).ToList()
            };

      
            TempData["actiontype"] = "forum";
            return View(result);
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
        //顯示所有看板
        public IActionResult Forum()
        {
            ForumViewModel model = new();
            model.ForumCollection = _service.GetForums();
            return View(model);
        }
        //顯示使用者的討論區
        public IActionResult MyForum()
        {
            if (User.Identity.IsAuthenticated)
            {
                ForumViewModel model = new();
                model.ForumCollection = _service.GetForums(User.Identity.Name);
                return View(model);
            }
            return Content("not login");
        }
    }
}
