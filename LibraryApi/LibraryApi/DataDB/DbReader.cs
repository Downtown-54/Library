using LibraryApi.Models;
using static LibraryApi.Models.Readers;

namespace LibraryApi.DataDB
{
    public class DbReader : IDisposable
    {
        private readonly IConfiguration Configuration;

        public DbReader(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IEnumerable<Readers>? GetReader()
        {
            try
            {
                Database db = new Database(Configuration);
                return db.Readers.ToList() ?? new List<Readers>();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<Readers>? AddReader(string reader, DateTime dateBirth, string numberPhone, string email, string address)
        {
            try
            {
                Database db = new Database(Configuration);
                var readerAdd = new Readers()
                {
                    Reader = reader,
                    DateBirth = dateBirth.ToUniversalTime(),
                    NumberPhone = numberPhone,
                    Email = email,
                    Address = address,
                    Status = StatusReader.active
                };
                db.Readers.Add(readerAdd);
                db.SaveChanges();
                return db.Readers.ToList() ?? new List<Readers>();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Readers>? UpdateReader(int id, string reader, DateTime dateBirth, string numberPhone, string email, string address)
        {
            try
            {
                Database db = new Database(Configuration);
                var readerUpdate = db.Readers.SingleOrDefault(b => b.Id == id);
                if (readerUpdate != null)
                {
                    readerUpdate.Reader = reader ?? readerUpdate.Reader;
                    readerUpdate.DateBirth = dateBirth != null ? dateBirth.ToUniversalTime() : readerUpdate.DateBirth;
                    readerUpdate.NumberPhone = numberPhone ?? readerUpdate.NumberPhone;
                    readerUpdate.Email = email ?? readerUpdate.Email;
                    readerUpdate.Address = address ?? readerUpdate.Address;
                    db.SaveChanges();
                }

                return db.Readers.ToList() ?? new List<Readers>(); ;
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
