using LibraryApi.Controllers;
using LibraryApi.DataDB;
using LibraryApi.Models;

namespace LibraryApi.Data
{
    public class DbIssuedBook : IDisposable, IDbIssuedBook
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<BookController> _logger;
        private Database db;

        public DbIssuedBook(IConfiguration configuration, ILogger<BookController> logger)
        {
            Configuration = configuration;
            _logger = logger;
            db = new Database(Configuration);
        }

        public IEnumerable<Readers>? AddIssuedBook(string author, string nameBook, DateTime dateOfDelivery, int id)
        {
            try
            {
                var selectBook = db.Books.SingleOrDefault(b => b.Name == nameBook && b.Author == author);
                var bookAdd = new IssuedBooks()
                {
                    IssuedDate = DateTime.Now,
                    NameBook = selectBook.Id,
                    Reader = id,
                    DateOfDelivery = dateOfDelivery.ToUniversalTime()
                };
                db.IssuedBooks.Add(bookAdd);

                db.SaveChanges();


                var selectReader = db.Readers.ToList() ?? new List<Readers>();

                return selectReader;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in AddIssuedBook", ex);
                return null;
            }
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public interface IDbIssuedBook
    {
        IEnumerable<Readers> AddIssuedBook(string author, string nameBook, DateTime dateOfDelivery, int id);
    }
}
