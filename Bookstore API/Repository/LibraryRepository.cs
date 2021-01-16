using Bookstore_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Bookstore_API.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private string _databasePath = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\Books.xml";
        public List<BookModel> GetBook(string input)
        {
            var books = new List<BookModel>();
            var xmlSerializer = new XmlSerializer(typeof(LibraryModel));
            using (var context = new StreamReader(_databasePath))
            {
                var library = (LibraryModel)xmlSerializer.Deserialize(context);

                books = library.Books.Where(
                    x => x.ISBN.Equals(input) ||
                    x.Author.Equals(input, StringComparison.OrdinalIgnoreCase) ||
                    x.Title.Equals(input, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return books;
        }

        public int GetBookCount()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_databasePath);
            var bookList = doc.GetElementsByTagName("Book");
            return bookList.Count;
        }

        public void SaveBook(BookModel book)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_databasePath);
            XmlElement bookNode = doc.CreateElement("Book");
            XmlElement title = doc.CreateElement("Title");
            XmlElement author = doc.CreateElement("Author");
            XmlElement isbn = doc.CreateElement("ISBN");
            title.InnerText = book.Title;
            author.InnerText = book.Author;
            isbn.InnerText = book.ISBN;
            bookNode.AppendChild(title);
            bookNode.AppendChild(author);
            bookNode.AppendChild(isbn);
            doc.DocumentElement.AppendChild(bookNode);
            doc.Save(_databasePath);
        }
    }
}