using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SqlModels.Data;
using SqlModels.Models;

namespace SenGame.Controllers
{
    public class ForaController : Controller
    {
        private readonly SenGameContext _context;

        public ForaController(SenGameContext context)
        {
            _context = context;
        }

        // GET: Fora
        public async Task<IActionResult> Index()
        {
            var senGameContext = _context.Forums.Include(f => f.Game);
            return View(await senGameContext.ToListAsync());
        }

        // GET: Fora/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = await _context.Forums
                .Include(f => f.Game)
                .FirstOrDefaultAsync(m => m.ForumId == id);
            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }

        // GET: Fora/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "Developer");
            return View();
        }

        // POST: Fora/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ForumId,Name,Banner,GameId")] Forum forum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "Developer", forum.GameId);
            return View(forum);
        }

        // GET: Fora/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = await _context.Forums.FindAsync(id);
            if (forum == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "Developer", forum.GameId);
            return View(forum);
        }

        // POST: Fora/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ForumId,Name,Banner,GameId")] Forum forum)
        {
            if (id != forum.ForumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumExists(forum.ForumId))
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
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "Developer", forum.GameId);
            return View(forum);
        }

        // GET: Fora/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = await _context.Forums
                .Include(f => f.Game)
                .FirstOrDefaultAsync(m => m.ForumId == id);
            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }

        // POST: Fora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forum = await _context.Forums.FindAsync(id);
            _context.Forums.Remove(forum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumExists(int id)
        {
            return _context.Forums.Any(e => e.ForumId == id);
        }
    }
}
