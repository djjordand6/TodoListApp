global using Microsoft.EntityFrameworkCore;

namespace TodoListApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TodoListDB;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
    }
}
