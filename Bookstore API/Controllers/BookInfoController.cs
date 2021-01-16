using Bookstore_API.Models;
using Bookstore_API.Repository;
using System.Net;
using System.Web.Http;

namespace Bookstore_API.Controllers
{
    [RoutePrefix("api")]
    public class BookInfoController : ApiController
    {
        private readonly ILibraryRepository _library;

        public BookInfoController(ILibraryRepository library)
        {
            _library = library;
        }

        [HttpGet]
        [Route("book/search")]
        public IHttpActionResult SearchBook(string input)
        {
            if (InputIsValid(input))
            {
                var books = _library.GetBook(input);
                if (books.Count == 0)
                {
                    return Content(HttpStatusCode.NotFound, $"Could not find any book related to {input}");

                };
                return Ok(books);
            }
            else { return BadRequest("Input is not valid."); }

        }

        [HttpPost]
        [Route("book/create")]
        public IHttpActionResult CreateBook(BookModel book)
        {
            if(book != null)
            {
                _library.SaveBook(book);
                return Ok($"{book.Title} by {book.Author} created successfully.");
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("book/getCount")]
        public int GetCount()
        {
            return _library.GetBookCount();
        }

        private bool InputIsValid(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return false;
            }
            return true;
        }
    }
}
