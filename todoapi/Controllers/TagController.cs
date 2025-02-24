using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly TodoContext _context;

        public TagController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/tag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
        {
            return await _context.Tags.ToListAsync();
        }

        // GET: api/tag/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Tag>> GetTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }

        // POST: api/tag
        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag([FromBody] Tag tag)
        {
            if (tag == null)
            {
                return BadRequest("Données invalides.");
            }

            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTag), new { id = tag.Id }, tag);
        }

        // PUT: api/tag/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutTag(int id, [FromBody] Tag tag)
        {
            if (tag == null || id != tag.Id)
            {
                return BadRequest("ID non valide ou données manquantes.");
            }

            var existingTag = await _context.Tags.FindAsync(id);
            if (existingTag == null)
            {
                return NotFound();
            }

            _context.Entry(existingTag).CurrentValues.SetValues(tag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/tag/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
