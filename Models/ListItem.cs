namespace TodoListApp.Models
{
    public class ListItem
    {
        public required int Id { get; set; }

        public required int UserId { get; set; }

        public required string ItemText { get; set; } = string.Empty;

        public required bool IsDone { get; set; } = false;

        public int Order {  get; set; }

        public required DateTime Created { get; set; }
    }
}
