using Bookstore_API.Models;
using Bookstore_API.Repository;
using System.Web.Http;

namespace Bookstore_API.Controllers
{
    public class BookInfoController : ApiController
    {
        private LibraryRepository library = new LibraryRepository();
        [HttpGet]
        public BookModel SearchBook(string ISBN)
        {

            var book = library.GetBook(ISBN);
            return book;
        }
    }
}
