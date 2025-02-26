using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
        {
            return await _context.TodoItems.ToListAsync();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null) return NotFound();
            return todoItem;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem([FromBody] TodoItem todoItem)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, [FromBody] TodoItem todoItem)
        {
            if (id != todoItem.Id) return BadRequest("ID mismatch");

            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null) return NotFound();

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
