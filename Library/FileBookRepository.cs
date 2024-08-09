using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library
{
    public class FileBookRepository : IBookRepository
    {
        private string FilePath { get; set; }
        private List<Book> Books { get; set; }

        public FileBookRepository(string filePath)
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
                var lines = File.ReadAllLines(FilePath);
                Books = lines.Select(line =>
                {
                    var parts = line.Split(',');
                    return new Book(parts[0], parts[1], parts[2], int.Parse(parts[3]), parts[4]);
                }).ToList();
            }
            else
            {
                Books = new List<Book>();
            }
        }

        private void SaveToFile()
        {
            var lines = Books.Select(book => $"{book.Title},{book.Author},{book.ISBN},{book.Year},{book.Description}");
            File.WriteAllLines(FilePath, lines);
        }
    }
}