using Bookstore_API.Models;
using System.Collections.Generic;

namespace Bookstore_API.Repository
{
    public interface ILibraryRepository
    {
        List<BookModel> GetBook(string ISBN);
        void SaveBook(BookModel book);
        int GetBookCount();
    }
}
