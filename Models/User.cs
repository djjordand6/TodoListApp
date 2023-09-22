namespace TodoListApp.Models
{
    public class User
    {
        public required int Id { get; set; }

        public required string Email { get; set; } = string.Empty;

        public required string Pass { get; set; } = string.Empty;

        public required string Name { get; set; } = string.Empty;
    }
}
