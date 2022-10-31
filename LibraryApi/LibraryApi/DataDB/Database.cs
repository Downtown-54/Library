using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Npgsql;

namespace LibraryApi.DataDB
{
    public class DatabaseContext : DbContext
    {
        //public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        //{ }
        public DbSet<IssuedBooks>? IssuedBooks { get; set; }

        public DbSet<Books>? Books { get; set; }

        public DbSet<Readers>? Readers { get; set; }
        public IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=masterkey");
        }


        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"]));
        //}
    }
}
