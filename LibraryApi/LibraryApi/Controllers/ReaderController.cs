using LibraryApi.DataDB;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReaderController : ControllerBase
    {
        // Получение читателей
        [HttpGet]
        public IEnumerable<Readers>? GetReader()
        {
            DatabaseContext db = new DatabaseContext();
            try
            {
                List<Readers> readerArrey = new List<Readers>();
                var selectReader = db.Readers.ToList() ?? new List<Readers>();
                if (selectReader != null)
                {
                    foreach (var reader in selectReader)
                    {
                        readerArrey.Add(reader);
                    }
                }
                return readerArrey;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Добавления читателя
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="dateBirth"></param>
        /// <param name="numberPhone"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddReader")]
        public IEnumerable<Readers>? AddReader(string reader, DateTime dateBirth, string numberPhone, string email, string address)
        {
            DatabaseContext db = new DatabaseContext();
            try
            {
                var readerAdd = new Readers() { Reader = reader, DateBirth = dateBirth.ToUniversalTime(), NumberPhone = numberPhone, Email = email,
                    Address = address, Status = 1 };
                db.Readers.Add(readerAdd);
                db.SaveChanges();

                List<Readers> readerArrey = new List<Readers>();
                var selectReader = db.Readers.ToList() ?? new List<Readers>();
                if (selectReader != null)
                {
                    foreach (var select in selectReader)
                    {
                        readerArrey.Add(select);
                    }
                }
                return readerArrey;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// обновление данных читателя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reader"></param>
        /// <param name="dateBirth"></param>
        /// <param name="numberPhone"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateReader")]
        public IEnumerable<Readers>? UpdateReader(int id, string reader, DateTime dateBirth, string numberPhone, string email, string address)
        {
            DatabaseContext db = new DatabaseContext();
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
                List<Readers> readerArrey = new List<Readers>();
                var selectReader = db.Readers.ToList() ?? new List<Readers>();
                if (selectReader != null)
                {
                    foreach (var select in selectReader)
                    {
                        readerArrey.Add(select);
                    }
                }
                return readerArrey;
            }
            catch
            {
                return null;
            }
        }
    }
}
