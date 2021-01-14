using Bookstore_API.Models;
using Bookstore_API.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace Bookstore_API.Controllers
{
    public class BookInfoController : ApiController
    {
        private LibraryRepository library = new LibraryRepository();


        [HttpGet]
        public IHttpActionResult SearchBook(string ISBN)
        {
            var book = library.GetBook(ISBN);

            var list = new List<BookModel>() { book };
            return Ok(list);

        }
    }
}
