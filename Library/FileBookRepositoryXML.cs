using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Library
{
    public class FileBookRepositoryXML : IBookRepository
    {
        private string FilePath { get; set; }
        private List<Book> Books { get; set; }

        public FileBookRepositoryXML(string filePath)
        {
            FilePath = filePath;
            LoadFromFile();
        }

        public List<Book> GetBooks()
        {
            return Books;
        }

        public Book GetBookById(int id)
        {
            return Books.ElementAtOrDefault(id);
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            SaveToFile();
        }

        public void UpdateBook(Book book)
        {
            var existingBook = GetBookById(Books.IndexOf(book));
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.Year = book.Year;
                existingBook.Description = book.Description;
                SaveToFile();
            }
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                Books.Remove(book);
                SaveToFile();
            }
        }

        private void LoadFromFile()
        {
            if (File.Exists(FilePath))
            {
                XDocument doc = XDocument.Load(FilePath);
                Books = doc.Root.Elements("Book")
                    .Select(x => new Book(
                        x.Element("Title").Value,
                        x.Element("Author").Value,
                        x.Element("ISBN").Value,
                        int.Parse(x.Element("Year").Value),
                        x.Element("Description").Value))
                    .ToList();
            }
            else
            {
                Books = new List<Book>();
            }
        }

        private void SaveToFile()
        {
            XDocument doc = new XDocument(
                new XElement("Books",
                    Books.Select(book =>
                        new XElement("Book",
                            new XElement("Title", book.Title),
                            new XElement("Author", book.Author),
                            new XElement("ISBN", book.ISBN),
                            new XElement("Year", book.Year),
                            new XElement("Description", book.Description)
                        )
                    )
                )
            );
            doc.Save(FilePath);
        }
    }
}

