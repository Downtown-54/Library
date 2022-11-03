using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using static LibraryApi.Models.Books;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private IDbBook _dbBook;
        private readonly ILogger<BookController> _logger;

        public BookController(IDbBook db, ILogger<BookController> logger)
        {
            _dbBook = db;
            _logger = logger;
        }

        /// <summary>
        /// Получение книг
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Books>? GetBook()
        {
            try
            {
                return _dbBook.GetBook();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetBook", ex);
                return null;
            }
        }

        /// <summary>
        /// Добавление кники
        /// </summary>
        /// <param name="name"></param>
        /// <param name="author"></param>
        /// <param name="vendorCode"></param>
        /// <param name="yearOfPublication"></param>
        /// <param name="instances"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddBook")]
        public IEnumerable<Books>? AddBook(string name, string author, string vendorCode, DateTime yearOfPublication, int instances)
        {
            try
            {
                return _dbBook.AddBook(name, author, vendorCode, yearOfPublication, instances);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in AddBook", ex);
                return null;
            }

        }

        /// <summary>
        /// Ообновления данных книги 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="author"></param>
        /// <param name="vendorCode"></param>
        /// <param name="yearOfPublication"></param>
        /// <param name="instances"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateBook")]
        public IEnumerable<Books>? UpdateBook(int id, string name, string author, string vendorCode, DateTime yearOfPublication, int instances)
        {
            try
            {
                return _dbBook.UpdateBook(id, name, author, vendorCode, yearOfPublication, instances);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in UpdateBook", ex);
                return null;
            }
        }
    }
}

