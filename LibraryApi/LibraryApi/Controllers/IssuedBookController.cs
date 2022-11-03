using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssuedBookController : ControllerBase
    {
        private IDbIssuedBook _dbIssuedBook;
        private readonly ILogger<BookController> _logger;

        public IssuedBookController(IDbIssuedBook db, ILogger<BookController> logger)
        {
            _dbIssuedBook = db;
            _logger = logger;
        }

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
            try
            {
                return _dbIssuedBook.AddIssuedBook(author, nameBook, dateOfDelivery, id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in AddIssuedBook", ex);
                return null;
            }
        }
    }
}