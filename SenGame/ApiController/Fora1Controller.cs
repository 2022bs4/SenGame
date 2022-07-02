using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlModels.Data;
using SqlModels.Models;

namespace SenGame.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Fora1Controller : ControllerBase
    {
        private readonly SenGameContext _context;

        public Fora1Controller(SenGameContext context)
        {
            _context = context;
        }

        // GET: api/Fora1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Forum>>> GetForums()
        {
            return await _context.Forums.ToListAsync();
        }

        // GET: api/Fora1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Forum>> GetForum(int id)
        {
            var forum = await _context.Forums.FindAsync(id);

            if (forum == null)
            {
                return NotFound();
            }

            return forum;
        }

        // PUT: api/Fora1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForum(int id, Forum forum)
        {
            if (id != forum.ForumId)
            {
                return BadRequest();
            }

            _context.Entry(forum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Fora1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Forum>> PostForum(Forum forum)
        {
            _context.Forums.Add(forum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ForumExists(forum.ForumId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetForum", new { id = forum.ForumId }, forum);
        }

        // DELETE: api/Fora1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForum(int id)
        {
            var forum = await _context.Forums.FindAsync(id);
            if (forum == null)
            {
                return NotFound();
            }

            _context.Forums.Remove(forum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ForumExists(int id)
        {
            return _context.Forums.Any(e => e.ForumId == id);
        }
    }
}
