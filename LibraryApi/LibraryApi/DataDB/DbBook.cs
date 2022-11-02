using LibraryApi.Models;
using static LibraryApi.Models.Books;

namespace LibraryApi.DataDB
{
    public class DbBook : IDisposable
    {
        private readonly IConfiguration Configuration;

        public DbBook(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IEnumerable<Books>? GetBook()
        {
            try
            {
                Database db = new Database(Configuration);
                return db.Books.ToList() ?? new List<Books>();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Books>? AddBook(string name, string author, string vendorCode, DateTime yearOfPublication, int instances)
        {
            try
            {
                Database db = new Database(Configuration);
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
                        Status = StatusBook.active
                    };
                    db.Books.Add(bookAdd);
                    db.SaveChanges();
                }

                return db.Books.ToList() ?? new List<Books>();
            }
            catch
            {
                return null;
            }

        }

        public IEnumerable<Books>? UpdateBook(int id, string name, string author, string vendorCode, DateTime yearOfPublication, int instances)
        {
            try
            {
                Database db = new Database(Configuration);
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
            catch
            {
                return null;
            }
        }

        protected void Dispose(bool disposing)
        {
            Database db = new Database(Configuration);
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
