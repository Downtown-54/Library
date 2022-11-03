using LibraryApi.Controllers;
using LibraryApi.DataDB;
using LibraryApi.Models;
using System.Net;
using System.Reflection.PortableExecutable;
using static LibraryApi.Models.Readers;

namespace LibraryApi.Data
{
    public class DbReader : IDisposable, IDbRedaers
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<BookController> _logger;
        private Database db;

        public DbReader(IConfiguration configuration, ILogger<BookController> logger)
        {
            Configuration = configuration;
            _logger = logger;
            db = new Database(Configuration);
        }

        public IEnumerable<Readers>? GetReader()
        {
            try
            {
                return db.Readers.ToList() ?? new List<Readers>();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetReader", ex);
                return null;
            }
        }
        public IEnumerable<Readers>? AddReader(string reader, DateTime dateBirth, string numberPhone, string email, string address)
        {
            try
            {
                var readerAdd = new Readers()
                {
                    Reader = reader,
                    DateBirth = dateBirth.ToUniversalTime(),
                    NumberPhone = numberPhone,
                    Email = email,
                    Address = address,
                    Status = StatusReader.Active
                };
                db.Readers.Add(readerAdd);
                db.SaveChanges();
                return db.Readers.ToList() ?? new List<Readers>();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in AddReader", ex);
                return null;
            }
        }

        public IEnumerable<Readers>? UpdateReader(int id, string reader, DateTime dateBirth, string numberPhone, string email, string address)
        {
            try
            {
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
            catch (Exception ex)
            {
                _logger.LogError("Error in UpdateReader", ex);
                return null;
            }
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public interface IDbRedaers
    {
        IEnumerable<Readers> GetReader();
        IEnumerable<Readers> AddReader(string reader, DateTime dateBirth, string numberPhone, string email, string address);
        IEnumerable<Readers> UpdateReader(int id, string reader, DateTime dateBirth, string numberPhone, string email, string address);
    }
}
