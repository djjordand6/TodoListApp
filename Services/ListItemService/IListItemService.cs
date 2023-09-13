using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.Services.ListItemService
{
    public interface IListItemService
    {
        List<ListItem> GetAllTodo();
        List<ListItem>? GetUserTodo(int userId);
        List<ListItem> AddTodo(ListItem li);
        List<ListItem>? EditTodo(int id, ListItem req);
        List<ListItem>? DeleteTodo(int id);
    }
}
