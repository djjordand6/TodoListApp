using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoListApp.Models;
using TodoListApp.Functions;
using System.Collections.Generic;

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

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> AddUser(User u)
        {
            string hp = Hasher.GetHash(u.Pass);
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

        public async Task<User?> GetUser(string email, string pass)
        {
            var hp = Hasher.GetHash(pass);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Pass == hp); //(u => u.Email == email && Hasher.VerifyHash(pass, u.Pass)

            if (user is null)
                return null;

            return user; //Should return user ID? and auth token (userID used to return all ListItem's with the corresponding UserID field)
        }
    }
}
