using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using SqlModels.Data;
using SqlModels.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace SenGame.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly SenGameContext _context;
        private readonly IBaseService<Article> _service;

        public ArticlesController(SenGameContext context, IBaseService<Article> service)
        {
            _context = context;
            _service = service;
        }

        // GET: Articles/{Forum.id}
        public IActionResult Index(int id)
        {
            var data = _service.FindBy(x => x.ForumId == id);
            return View(data);
        }

        // GET: Articles/Details/{Articles.Id}
        public IActionResult Details(int id)
        {
            var article = _service.GetById(id);
            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["ArticleTagId"] = new SelectList(_context.ArticleTags, "ArticleTagId", "TagName");
            ViewData["ForumId"] = new SelectList(_context.Forums, "ForumId", "Banner");
            ViewData["UserId"] = new SelectList(_context.Set<UserModel>(), "UserId", "Id");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Content,Title,ForumId,ArticleTagId")] Article article)
        {
            article.ArticleId = _service.GetAll().Last().ArticleId + 1;
            article.UserId = "0";
            article.PostTime = DateTime.Now;
            article.LastReplyTime = DateTime.Now;
            article.ForumId = 0;
            if (ModelState.IsValid)
            {
                _service.Create(article);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleTagId"] = new SelectList(_context.ArticleTags, "ArticleTagId", "TagName", article.ArticleTagId);
            ViewData["ForumId"] = new SelectList(_context.Forums, "ForumId", "Banner", article.ForumId);
            ViewData["UserId"] = new SelectList(_context.Set<UserModel>(), "UserId", "Id", article.UserId);

            return View(article);
        }

        // GET: Articles/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return Content("沒有帶ID參數");
            }
            var article = _service.GetById((int)id);
            if (article == null)
            {
                return Content("找不到ID為"+id+"的文章");
            }
            ViewData["ArticleTagId"] = new SelectList(_context.ArticleTags, "ArticleTagId", "TagName", article.ArticleTagId);
            ViewData["ForumId"] = new SelectList(_context.Forums, "ForumId", "Banner", article.ForumId);
            ViewData["UserId"] = new SelectList(_context.Set<UserModel>(), "UserId", "Id", article.UserId);
            return View(article);
        }

        // POST: Articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ArticleId,UserId,Content,PostTime,Title,ForumId,LastReplyTime,ArticleTagId")] Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(article);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ArticleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleTagId"] = new SelectList(_context.ArticleTags, "ArticleTagId", "TagName", article.ArticleTagId);
            ViewData["ForumId"] = new SelectList(_context.Forums, "ForumId", "Banner", article.ForumId);
            ViewData["UserId"] = new SelectList(_context.Set<UserModel>(), "UserId", "Id", article.UserId);
            return View(article);
        }

        // GET: Articles/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Content("not found");
            }

            //var article = await _context.Articles
            //    .Include(a => a.ArticleTag)
            //    .Include(a => a.Forum)
            //    .Include(a => a.User)
            //    .FirstOrDefaultAsync(m => m.ArticleId == id); 
            var article =  _service.GetById((int)id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var article = _service.GetById(id);
            _service.Delete(article);
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}
