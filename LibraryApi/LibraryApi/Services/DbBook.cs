using LibraryApi.Controllers;
using LibraryApi.DataDB;
using LibraryApi.Models;
using static LibraryApi.Models.Books;

namespace LibraryApi.Data
{
    public class DbBook : IDisposable, IDbBook
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<BookController> _logger;
        private Database db;
        public DbBook(IConfiguration configuration, ILogger<BookController> logger)
        {
            Configuration = configuration;
            _logger = logger;
            db = new Database(Configuration);
        }
        public IEnumerable<Books>? GetBook()
        {
            try
            {
                return db.Books.ToList() ?? new List<Books>();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetBook", ex);
                return null;
            }
        }

        public IEnumerable<Books>? AddBook(string name, string author, string vendorCode, DateTime yearOfPublication, int instances)
        {
            try
            {
                var vendorCodeBook = db.Books.SingleOrDefault(b => b.VendorCode == vendorCode);
                if (vendorCodeBook == null)
                {
                    var bookAdd = new Books()
                    {
                        Name = name,
                        Author = author,
                        VendorCode = vendorCode,
                        YearOfPublication = yearOfPublication.ToUniversalTime(),
                        Instances = instances,
                        Status = StatusBook.Active
                    };
                    db.Books.Add(bookAdd);
                    db.SaveChanges();
                }

                return db.Books.ToList() ?? new List<Books>();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in AddBook", ex);
                return null;
            }

        }

        public IEnumerable<Books>? UpdateBook(int id, string name, string author, string vendorCode, DateTime yearOfPublication, int instances)
        {
            try
            {
                var bookUpdate = db.Books.SingleOrDefault(b => b.Id == id);
                if (bookUpdate != null)
                {
                    bookUpdate.Name = name ?? bookUpdate.Name;
                    bookUpdate.Author = author ?? bookUpdate.Author;
                    bookUpdate.VendorCode = vendorCode ?? bookUpdate.VendorCode;
                    bookUpdate.YearOfPublication = yearOfPublication != null ? yearOfPublication.ToUniversalTime() : bookUpdate.YearOfPublication;
                    bookUpdate.Instances = instances == 0 ? bookUpdate.Instances : instances;
                    db.SaveChanges();
                }
                return db.Books.ToList() ?? new List<Books>();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in UpdateBook", ex);
                return null;
            }
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public interface IDbBook
    {
        IEnumerable<Books> GetBook();
        IEnumerable<Books> AddBook(string name, string author, string vendorCode, DateTime yearOfPublication, int instances);
        IEnumerable<Books> UpdateBook(int id, string name, string author, string vendorCode, DateTime yearOfPublication, int instances);
    }
}
