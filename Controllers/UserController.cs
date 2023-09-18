using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using TodoListApp.Models;
using TodoListApp.Services.UserService;

namespace TodoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("{email} {pass}")]
        public async Task<ActionResult<string>> GetUser(String email, String pass)
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
