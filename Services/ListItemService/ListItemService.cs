namespace TodoListApp.Services.ListItemService
{
    public class ListItemService : IListItemService
    {
        private static List<ListItem> todo = new List<ListItem>
        {
            new ListItem { Id = 1, UserId = 1, ItemText = "Test" },
            new ListItem { Id = 2, UserId = 1, ItemText = "Test Again" },
            new ListItem { Id = 3, UserId = 1, ItemText = "Test Again Again" },
            new ListItem { Id = 4, UserId = 2, ItemText = "Test for user 2" }
        };

        public List<ListItem> AddTodo(ListItem li)
        {
            todo.Add(li);
            return todo;
        }

        public List<ListItem>? DeleteTodo(int id)
        {
            var item = todo.Find(x => x.Id == id);
            if (item is null)
                return null;

            todo.Remove(item);
            return todo;
        }

        public List<ListItem>? EditTodo(int id, ListItem req)
        {
            var item = todo.Find(x => x.Id == id);
            if (item is null)
                return null;

            item.ItemText = req.ItemText;

            return todo;
        }

        public List<ListItem> GetAllTodo()
        {
            return todo;
        }

        public List<ListItem>? GetUserTodo(int userId)
        {
            var items = todo.FindAll(x => x.UserId == userId);

            if (items is null)
                return null;

            return items;

        }
    }
}
