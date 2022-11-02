using LibraryApi.Models;

namespace LibraryApi.DataDB
{
    public class DbIssuedBook : IDisposable
    {
        private readonly IConfiguration Configuration;

        public DbIssuedBook(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IEnumerable<Readers>? AddIssuedBook(string author, string nameBook, DateTime dateOfDelivery, int id)
        {
            try
            {
                Database db = new Database(Configuration);
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
