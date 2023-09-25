using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoListApp.Models;
using TodoListApp.Functions;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.ObjectPool;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TodoListApp.Services.UserService
{
    public class UserService : IUserService
    {
        // Temp Variable to test methods
        //private static List<User> users = new List<User>
        //{
        //    new User { Id = 1, Email = "test@test.com", Pass = "hello123", Name = "Test User 1" }, //No Hashing
        //    new User { Id = 2, Email = "test2@testing.com", Pass = "goodbye456", Name = "Test User 2" }
        //};

        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public UserService(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<List<User>> AddUser(User u)
        {
            //string hp = Hasher.GetHash(u.Pass);
            string hp = BCrypt.Net.BCrypt.HashPassword(u.Pass);
            u.Pass = hp;

            _context.Users.Add(u);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<string?> GetUser(string email, string pass)
        {
            //var hp = Hasher.GetHash(pass);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email); //(u => u.Email == email && Hasher.VerifyHash(pass, u.Pass) //u.Pass == hp

            if (user is null || !BCrypt.Net.BCrypt.Verify(pass, user.Pass))
                return null;

            string token = CreateToken(user);

            return token; //Should return user ID? and auth token (userID used to return all ListItem's with the corresponding UserID field)
        }

        public string CreateToken(User u)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, u.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddMinutes(10), signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
