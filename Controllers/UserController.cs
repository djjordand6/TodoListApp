using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using TodoListApp.Models;
using TodoListApp.Services.UserService;

namespace TodoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("{email} {pass}")]
        public async Task<ActionResult<User>> GetUser(String email, String pass)
        {
            var result = await _userService.GetUser(email, pass);

            if(result is null)
                return NotFound("User not found");

            return result; //Should return user ID and auth token (userID used to return all ListItem's with the corresponding UserID field)
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User u)
        {
            return await _userService.AddUser(u);
        }
    }
}
