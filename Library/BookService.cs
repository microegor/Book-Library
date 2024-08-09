using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class BookService
    {
        private IBookRepository repository;

        public BookService(IBookRepository repository)
        {
            this.repository = repository;
        }

        public List<Book> SearchBooks(string query)
        {
            query = query.ToLower();
            return repository.GetBooks()
                .Where(book => book.Title.ToLower().Contains(query) || book.Author.ToLower().Contains(query))
                .ToList();
        }


        public void AddBook(Book book)
        {
            repository.AddBook(book);
        }

        public void UpdateBook(Book book)
        {
            repository.UpdateBook(book);
        }

        public void DeleteBook(int id)
        {
            repository.DeleteBook(id);
        }
    }
}