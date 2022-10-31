using LibraryApi.DataDB;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        // Получение книг
        [HttpGet]
        public IEnumerable<Books>? GetBook()
        {
            DatabaseContext db = new DatabaseContext();
            try
            {
                List<Books> bookArrey = new List<Books>();
                var selectBook = db.Books.ToList() ?? new List<Books>();
                if (selectBook != null)
                {
                    foreach (var book in selectBook)
                    {
                        bookArrey.Add(book);
                    }
                }
                return bookArrey;
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
            DatabaseContext db = new DatabaseContext();
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
                        Status = 1
                    };
                    db.Books.Add(bookAdd);
                    db.SaveChanges();
                }
                List<Books> bookArrey = new List<Books>();
                var selectBook = db.Books.ToList() ?? new List<Books>();
                if (selectBook != null)
                {
                    foreach (var book in selectBook)
                    {
                        bookArrey.Add(book);
                    }
                }
                return bookArrey;
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
            DatabaseContext db = new DatabaseContext();
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

                List<Books> bookArrey = new List<Books>();
                var selectBook = db.Books.ToList() ?? new List<Books>();
                if (selectBook != null)
                {
                    foreach (var book in selectBook)
                    {
                        bookArrey.Add(book);
                    }
                }
                return bookArrey;
            }
            catch
            {
                return null;
            }
        }
    }
}

