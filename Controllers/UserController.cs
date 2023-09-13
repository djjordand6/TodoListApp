using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using TodoListApp.Models;

namespace TodoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Temp Variable to test methods
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Email = "test@test.com", Pass = "hello123", Name = "Test User 1" }, //No Hashing
            new User { Id = 2, Email = "test2@testing.com", Pass = "goodbye456", Name = "Test User 2" }
        };

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{email} {pass}")]
        public async Task<ActionResult<User>> GetUser(String email, String pass)
        {
            var user = users.Find(user => user.Email == email && user.Pass == pass);

            if(user is null)
                return NotFound("User not found");

            return Ok(user); //Should return user ID and auth token (userID used to return all ListItem's with the corresponding UserID field)
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser([FromBody] User u)
        {
            users.Add(u);
            return Ok(users);
        }
    }
}
