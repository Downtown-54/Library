using LibraryApi.DataDB;
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
        private readonly IConfiguration Configuration;

        public BookController(IConfiguration configuration)
        {
            Configuration = configuration;

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
                var dbBook = new DbBook(Configuration);
                return dbBook.GetBook();
            }
            catch
            {
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
                var dbBook = new DbBook(Configuration);
                return dbBook.AddBook(name, author, vendorCode, yearOfPublication, instances);
            }
            catch
            {
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
                var dbBook = new DbBook(Configuration);
                return dbBook.UpdateBook(id, name, author, vendorCode, yearOfPublication, instances);
            }
            catch
            {
                return null;
            }
        }
    }
}

