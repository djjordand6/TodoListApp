namespace TodoListApp.Models
{
    public class ListItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string ItemText { get; set; } = string.Empty;
    }
}
