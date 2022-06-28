using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SenGame.Data;
using SqlModels.Models;
using SqlModels.Repository;

namespace SenGame.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly GenericRepository<Article> _Repository;
        private readonly DbContext _context;
        public ArticlesController(SenGameContext context)
        {
            this._Repository = new GenericRepository<Article>(context);
            _context = _Repository.DbContext;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var senGameContext = _context.Set<Article>().Include(a => a.ArticleTag).Include(a => a.Forum);
            return View(await senGameContext.ToListAsync());
        }
    }
}
