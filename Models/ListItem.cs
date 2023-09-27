namespace TodoListApp.Models
{
    public class ListItem
    {
        public int Id { get; set; }

        public int UserId { get; set; } //public virtual User User { get; set; }

        public required string ItemText { get; set; } = string.Empty;

        public bool IsDone { get; set; } = false;

        public int Order {  get; set; }

        public DateTime Created { get; set; }
    }
}
