using LibraryApi.DataDB;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using static LibraryApi.Models.Readers;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReaderController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public ReaderController(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        
        /// <summary>
        /// Получение читателей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Readers>? GetReader()
        {
            try
            {
                var dbReader = new DbReader(Configuration);
                return dbReader.GetReader();
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
            try
            {
                var dbReader = new DbReader(Configuration);
                return dbReader.AddReader(reader, dateBirth, numberPhone, email, address);
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
            try
            {
                var dbReader = new DbReader(Configuration);
                return dbReader.UpdateReader(id, reader, dateBirth, numberPhone, email, address);
            }
            catch
            {
                return null;
            }
        }
    }
}
