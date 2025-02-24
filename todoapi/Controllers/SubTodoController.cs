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
    public class SubTodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public SubTodoController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/subtodo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubTodo>>> GetSubTodos()
        {
            return await _context.SubTodos.ToListAsync();
        }

        // GET: api/subtodo/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SubTodo>> GetSubTodo(int id)
        {
            var subTodo = await _context.SubTodos.FindAsync(id);
            if (subTodo == null)
            {
                return NotFound();
            }
            return Ok(subTodo);
        }

        // POST: api/subtodo
        [HttpPost]
        public async Task<ActionResult<SubTodo>> PostSubTodo([FromBody] SubTodo subTodo)
        {
            if (subTodo == null)
            {
                return BadRequest("Données invalides.");
            }

            // Vérifier si le ParentTodoId existe dans la table TodoItems
            var parentTodo = await _context.TodoItems.FindAsync(subTodo.ParentTodoId);
            if (parentTodo == null)
            {
                return BadRequest("Le TodoItem parent spécifié n'existe pas.");
            }

            _context.SubTodos.Add(subTodo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubTodo), new { id = subTodo.Id }, subTodo);
        }


        // PUT: api/subtodo/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutSubTodo(int id, [FromBody] SubTodo subTodo)
        {
            if (subTodo == null || id != subTodo.Id)
            {
                return BadRequest("ID non valide ou données manquantes.");
            }

            var existingSubTodo = await _context.SubTodos.FindAsync(id);
            if (existingSubTodo == null)
            {
                return NotFound();
            }

            _context.Entry(existingSubTodo).CurrentValues.SetValues(subTodo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/subtodo/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSubTodo(int id)
        {
            var subTodo = await _context.SubTodos.FindAsync(id);
            if (subTodo == null)
            {
                return NotFound();
            }

            _context.SubTodos.Remove(subTodo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
