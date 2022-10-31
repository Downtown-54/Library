using LibraryApi.DataDB;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssuedBookController : ControllerBase
    {
        /// <summary>
        /// Выдача книг
        /// </summary>
        /// <param name="author"></param>
        /// <param name="nameBook"></param>
        /// <param name="dateOfDelivery"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<Readers>? AddIssuedBook(string author, string nameBook, DateTime dateOfDelivery, int id)
        {
            DatabaseContext db = new DatabaseContext();
            try
            {
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