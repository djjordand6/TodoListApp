using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.Services.UserService
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User? GetUser(String email, String pass);
        List<User> AddUser(User u);
    }
}
