using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<string?> GetUser(String email, String pass);
        Task<List<User>> AddUser(User u);
        string CreateToken(User u);
    }
}
