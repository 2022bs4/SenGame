using Microsoft.AspNetCore.Mvc;
using SqlModels.Models;
using Services.Interface;

namespace SenGame.Controllers
{
    public class CommunityController : Controller
    {
        private readonly IService _service;
        public CommunityController(IService service)
        {
            //this._service = new GenericService<Forum>(context);
            this._service = service;
        }
        public IActionResult Index()
        {

            return View();
        }
        //顯示討論區
        public IActionResult Forum() { 
            
            var data=_service.GetAll<Forum>();
            return View(data);
        }
        public IActionResult ComomunityDynamicwall()
        {
            return View(); 
        }
    }
}
