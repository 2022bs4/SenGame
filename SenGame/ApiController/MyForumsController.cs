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
    public class MyForumsController : ControllerBase
    {
        private readonly SenGameContext _context;

        public MyForumsController(SenGameContext context)
        {
            _context = context;
        }

        // GET: api/MyForums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyForum>>> GetMyForums()
        {
            return await _context.MyForums.ToListAsync();
        }

        // GET: api/MyForums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyForum>> GetMyForum(int id)
        {
            var myForum = await _context.MyForums.FindAsync(id);

            if (myForum == null)
            {
                return NotFound();
            }

            return myForum;
        }

        // PUT: api/MyForums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyForum(int id, MyForum myForum)
        {
            if (id != myForum.MyForumId)
            {
                return BadRequest();
            }

            _context.Entry(myForum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyForumExists(id))
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

        // POST: api/MyForums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyForum>> PostMyForum(MyForum myForum)
        {
            _context.MyForums.Add(myForum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MyForumExists(myForum.MyForumId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMyForum", new { id = myForum.MyForumId }, myForum);
        }

        // DELETE: api/MyForums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyForum(int id)
        {
            var myForum = await _context.MyForums.FindAsync(id);
            if (myForum == null)
            {
                return NotFound();
            }

            _context.MyForums.Remove(myForum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyForumExists(int id)
        {
            return _context.MyForums.Any(e => e.MyForumId == id);
        }
    }
}
