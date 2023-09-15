using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUser(String email, String pass);
        Task<List<User>> AddUser(User u);
    }
}
