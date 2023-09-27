using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.Services.ListItemService
{
    public interface IListItemService
    {
        // Task<List<ListItem>> GetAllTodo();
        Task<List<ListItem>?> GetUserTodo(int userId);
        Task<List<ListItem>> AddTodo(ListItem li);
        Task<List<ListItem>?> EditTodo(int id, ListItem req, int userId);
        Task<List<ListItem>?> DeleteTodo(int id, int userId);
        Task<ListItem?> SetTodoStatus(int id, int userId);
    }
}
