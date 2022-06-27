using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SenGame.Data;
using SenGame.Repository;
using SqlModels.Models;

namespace SenGame.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly GenericRepository<Article> _Repository;
        private readonly SenGameContext _context;
        public ArticlesController(SenGameContext context)
        {
            this._Repository = new GenericRepository<Article>(context);
            _context = _Repository.Context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var senGameContext = _context.Articles.Include(a => a.ArticleTag).Include(a => a.Forum);
            return View(await senGameContext.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.ArticleTag)
                .Include(a => a.Forum)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["ArticleTagId"] = new SelectList(_context.ArticleTags, "ArticleTagId", "TagName");
            ViewData["ForumId"] = new SelectList(_context.Forums, "ForumId", "Banner");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleId,UserId,ArticleContent,PostDate,Title,ForumId,LastReplyTime,ArticleTagId")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleTagId"] = new SelectList(_context.ArticleTags, "ArticleTagId", "TagName", article.ArticleTagId);
            ViewData["ForumId"] = new SelectList(_context.Forums, "ForumId", "Banner", article.ForumId);
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["ArticleTagId"] = new SelectList(_context.ArticleTags, "ArticleTagId", "TagName", article.ArticleTagId);
            ViewData["ForumId"] = new SelectList(_context.Forums, "ForumId", "Banner", article.ForumId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleId,UserId,ArticleContent,PostDate,Title,ForumId,LastReplyTime,ArticleTagId")] Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
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
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.ArticleTag)
                .Include(a => a.Forum)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}
