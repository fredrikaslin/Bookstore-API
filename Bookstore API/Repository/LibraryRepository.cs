using Bookstore_API.Models;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Bookstore_API.Repository
{
    internal class LibraryRepository
    {
        private string _databasePath = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\Books.xml";
        internal BookModel GetBook(string ISBN)
        {
            var book = new BookModel();
            var xmlSerializer = new XmlSerializer(typeof(LibraryModel));
            using (var context = new StreamReader(_databasePath))
            {
                var library = (LibraryModel)xmlSerializer.Deserialize(context);
                book = library.Books.FirstOrDefault(x => x.ISBN.Equals(ISBN));
                if (book == null)
                {
                    book = new BookModel()
                    {
                        Title = "book not found!"
                    };
                }
            }
            return book;
        }
    }
}