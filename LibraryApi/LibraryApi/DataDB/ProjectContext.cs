using LibraryApi.Models;
using System.Data.Entity;

namespace LibraryApi.DataDB
{
    public class ProjectContext : DbContext
    {
        public DbSet<IssuedBooks>? IssuedBooks { get; set; }

        public DbSet<Books>? Books { get; set; }

        public DbSet<Readers>? Readers { get; set; }
    }
}
