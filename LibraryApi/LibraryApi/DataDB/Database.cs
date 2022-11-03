using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;


namespace LibraryApi.DataDB
{
    public class Database : DbContext
    {
        public DbSet<IssuedBooks>? IssuedBooks { get; set; }

        public DbSet<Books>? Books { get; set; }

        public DbSet<Readers>? Readers { get; set; }

        private readonly IConfiguration Configuration;

        public Database(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
