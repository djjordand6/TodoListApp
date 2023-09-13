using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoListApp.Models;

namespace TodoListApp.Services.UserService
{
    public class UserService : IUserService
    {
        // Temp Variable to test methods
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Email = "test@test.com", Pass = "hello123", Name = "Test User 1" }, //No Hashing
            new User { Id = 2, Email = "test2@testing.com", Pass = "goodbye456", Name = "Test User 2" }
        };

        public List<User> AddUser(User u)
        {
            users.Add(u);
            return users;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User? GetUser(string email, string pass)
        {
            var user = users.Find(u => u.Email == email && u.Pass == pass);

            if (user is null)
                return null;

            return user; //Should return user ID and auth token (userID used to return all ListItem's with the corresponding UserID field)
        }
    }
}
