using Microsoft.AspNetCore.Mvc;
using SenGame.Data;
using SqlModels.Models;
using Services;
using Services.Interface;

namespace SenGame.Controllers
{
    public class CommunityController : Controller
    {
        private readonly IService<Forum> _service;
        public CommunityController(SenGameContext context)
        {
            //this._service = new GenericService<Forum>(context);
            this._service = new ForumService(context);
        }
        public IActionResult Index()
        {

            return View();
        }
        //顯示討論區
        public IActionResult Forum() { 
            
            var data=_service.GetAll();
            return View(data);
        }
        public IActionResult ComomunityDynamicwall()
        {
            return View(); 
        }
    }
}
