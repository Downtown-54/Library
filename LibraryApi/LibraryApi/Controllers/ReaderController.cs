using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReaderController : ControllerBase
    {
        private IDbRedaers _dbReader;
        private readonly ILogger<BookController> _logger;

        public ReaderController(IDbRedaers db, ILogger<BookController> logger)
        {
            _dbReader = db;
            _logger = logger;
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
                return _dbReader.GetReader();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetReader", ex);
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
                return _dbReader.AddReader(reader, dateBirth, numberPhone, email, address);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in AddReader", ex);
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
                return _dbReader.UpdateReader(id, reader, dateBirth, numberPhone, email, address);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in UpdateReader", ex);
                return null;
            }
        }
    }


}
