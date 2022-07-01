using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SqlModels.Data;
using SqlModels.Models;
using Services;
using Services.Interface;

namespace SenGame.Controllers
{
    public class ForaController : Controller
    {
        //private readonly IBaseService<Forum> _service;
        private readonly ICommunityService _service;

        public ForaController(ICommunityService service)
        {
            _service = service;
        }

        // GET: Fora
        public IActionResult Index()
        {
            var senGameContext = _service.GetAll();
            return View(senGameContext);
        }

        // GET: Fora/Details/5
    }
}