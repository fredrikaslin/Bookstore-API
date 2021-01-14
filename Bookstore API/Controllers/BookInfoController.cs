using Bookstore_API.Models;
using Bookstore_API.Repository;
using System.Web.Http;
using System.Web.Mvc;

namespace Bookstore_API.Controllers
{
    public class BookInfoController : ApiController
    {
        private LibraryRepository library = new LibraryRepository();


        [HttpGet]
        public ActionResult SearchBook(string ISBN)
        {
            var book = library.GetBook(ISBN);
            return book;

        }
    }
}
