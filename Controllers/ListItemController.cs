using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;

namespace TodoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListItemController : ControllerBase
    {
        // Temp Variable to test methods
        private static List<ListItem> todo = new List<ListItem>
        {
            new ListItem { Id = 1, UserId = 1, ItemText = "Test" },
            new ListItem { Id = 2, UserId = 1, ItemText = "Test Again" },
            new ListItem { Id = 3, UserId = 1, ItemText = "Test Again Again" },
            new ListItem { Id = 4, UserId = 2, ItemText = "Test for user 2" }
        };

        [HttpGet]
        public async Task<ActionResult<List<ListItem>>> GetAllTodo() //Delete method, should not retrieve for all users
        {
            return Ok(todo);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<ListItem>>> GetUserTodo(int userId)
        {
            var items = todo.Find(x => x.UserId == userId);

            if (items is null)
                return NotFound("No Todo Items found!");

            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<List<ListItem>>> AddTodo([FromBody] ListItem li)
        {
            todo.Add(li);
            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ListItem>>> EditTodo(int id, ListItem req)
        {
            var item = todo.Find(x => x.Id == id);
            if (item is null)
                return NotFound("Todo Item not found");

            item.ItemText = req.ItemText;

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ListItem>>> DeleteTodo(int id)
        {
            var item = todo.Find(x => x.Id == id);
            if (item is null)
                return NotFound("Todo Item not found");

            todo.Remove(item);
            return Ok(todo);
        }
    }
}
