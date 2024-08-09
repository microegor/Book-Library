using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class MemoryBookRepository : IBookRepository
    {
        private List<Book> Books { get; set; }

        public MemoryBookRepository()
        {
            Books = new List<Book>
            {
                new Book("Война и мир", "Лев Толстой", "1234567890", 1869, "Эпический роман"),
                new Book("Преступление и наказание", "Фёдор Достоевский", "0987654321", 1866, "Психологический роман"),
                new Book("Мастер и Маргарита", "Михаил Булгаков", "1122334455", 1967, "Мистический роман")
            };
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
            }
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                Books.Remove(book);
            }
        }
    }
}