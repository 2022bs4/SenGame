using Microsoft.AspNetCore.Mvc;
using SqlModels.Models;
using SqlModels.ViewModels;
using System.Collections.Generic;

namespace SenGame.Controllers
{
    public class CommunityController : Controller
    {
       
       
        public IActionResult Index()
        {

            return View();
        }
        //顯示討論區
        public IActionResult Forum() { return View(); }
        public IActionResult ComomunityDynamicwall()
        {
            return View();
        }
    }
}
