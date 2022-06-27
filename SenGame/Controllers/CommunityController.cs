using Microsoft.AspNetCore.Mvc;
using SenGame.Data;
using SenGame.Repository;
using SqlModels.Models;
using System.Linq;

namespace SenGame.Controllers
{
    public class CommunityController : Controller
    {
        private readonly GenericRepository<Forum> _Repository;
        public CommunityController(SenGameContext context)
        {
            this._Repository = new GenericRepository<Forum>(context);
        }
        public IActionResult Index()
        {

            return View();
        }
        //顯示討論區
        public IActionResult Forum() { 
            
            var data=_Repository.GetAll();
            return View(data);
        }
        public IActionResult ComomunityDynamicwall()
        {
            return View(); 
        }
    }
}
