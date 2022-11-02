using LibraryApi.DataDB;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssuedBookController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public IssuedBookController(IConfiguration configuration)
        {
            Configuration = configuration;

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
                var DbIssuedBook = new DbIssuedBook(Configuration);
                return DbIssuedBook.AddIssuedBook(author, nameBook, dateOfDelivery, id);
            }
            catch
            {
                return null;
            }
        }
    }
}