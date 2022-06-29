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
        private readonly IService _service;

        public ForaController(IService service)
        {
            _service = service;
        }

        // GET: Fora
        public async Task<IActionResult> Index()
        {
            var senGameContext = _service.GetAll<Forum>();
            return View(await senGameContext.ToListAsync());
        }

        // GET: Fora/Details/5
    }
}