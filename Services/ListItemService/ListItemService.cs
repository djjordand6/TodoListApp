namespace TodoListApp.Services.ListItemService
{
    public class ListItemService : IListItemService
    {
        //private static List<ListItem> todo = new List<ListItem>
        //{
        //    new ListItem { Id = 1, UserId = 1, ItemText = "Test" },
        //    new ListItem { Id = 2, UserId = 1, ItemText = "Test Again" },
        //    new ListItem { Id = 3, UserId = 1, ItemText = "Test Again Again" },
        //    new ListItem { Id = 4, UserId = 2, ItemText = "Test for user 2" }
        //};

        private readonly DataContext _context;

        public ListItemService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ListItem>> AddTodo(ListItem li)
        {
            _context.ListItems.Add(li);
            await _context.SaveChangesAsync();
            return await _context.ListItems.ToListAsync();
        }

        public async Task<List<ListItem>?> DeleteTodo(int id)
        {
            var item = await _context.ListItems.FindAsync(id);
            if (item is null)
                return null;

            _context.ListItems.Remove(item);
            await _context.SaveChangesAsync();

            return await _context.ListItems.ToListAsync();
        }

        public async Task<List<ListItem>?> EditTodo(int id, ListItem req)
        {
            var item = await _context.ListItems.FindAsync(id);
            if (item is null)
                return null;

            item.ItemText = req.ItemText;

            await _context.SaveChangesAsync();

            return await _context.ListItems.ToListAsync();
        }

        public async Task<List<ListItem>> GetAllTodo()
        {
            return await _context.ListItems.ToListAsync();
        }

        public async Task<List<ListItem>?> GetUserTodo(int userId)
        {
            var items = await _context.ListItems.Where(li => li.UserId == userId).ToListAsync();

            if (items is null)
                return null;

            return items;

        }
    }
}
