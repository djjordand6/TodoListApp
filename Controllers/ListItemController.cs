using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;
using TodoListApp.Services.ListItemService;

namespace TodoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListItemController : ControllerBase
    {

        private readonly IListItemService _listItemService;

        public ListItemController(IListItemService listItemService)
        {
            _listItemService = listItemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListItem>>> GetAllTodo() //Delete method, should not retrieve for all users
        {
            return await _listItemService.GetAllTodo();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<ListItem>>> GetUserTodo(int userId)
        {
            var items = await _listItemService.GetUserTodo(userId);

            if (items is null)
                return NotFound("No Todo Items found!");

            return items;
        }

        [HttpPost]
        public async Task<ActionResult<List<ListItem>>> AddTodo(ListItem li)
        {
            return await _listItemService.AddTodo(li);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ListItem>>> EditTodo(int id, ListItem req)
        {
            var item = await _listItemService.EditTodo(id, req);
            if (item is null) 
                return NotFound("Todo Item not found");

            return item;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ListItem>>> DeleteTodo(int id)
        {
            var item = await _listItemService.DeleteTodo(id);
            if (item is null)
                return NotFound("Todo Item not found");

            return item;
        }
    }
}
