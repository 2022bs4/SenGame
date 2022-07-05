using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using SqlModels.Models;
using System;
using SqlModels.ViewModels;

namespace SenGame.Controllers
{
    public class CommunityController : Controller
    {

        private readonly ICommunityService _services;
        //private readonly IBaseService<Forum> _service;
        public CommunityController(ICommunityService service)
        {
            this._services = service;
        }
        //public CommunityController(IBaseService<Forum> service)
        //{
        //    //this._service = new GenericService<Forum>(context);
        //    this._service = service;
            
        //}
        public IActionResult Index()
        {
            var articles = _services.Article();
            var Articles = new List<CommunityViewModel>();
            foreach(var item in articles)
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
        //顯示討論區
        public IActionResult Forum() { 
            
            //var data=_service.GetAll();
            TempData["actiontype"] = "forum";
            return View();
        }
        public IActionResult ComomunityDynamicwall()
        {
            TempData["actiontype"] = "forum";
            return View(); 
        }

        [HttpGet]
        public IActionResult Swipers()
        {
            var img = _services.Swipers().ToArray();
            return Ok(img);
        }

    //    [HttpGet]
    //    public IActionResult Articles()
    //    {
    //        var articles = _services.Article().ToArray();
    //        return Ok(articles);
    //    }
    }
}
