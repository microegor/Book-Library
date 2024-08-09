using System;
using System.Collections.Generic;
using System.Linq;
using Library;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBookRepository repository = new FileBookRepository("books.txt");
            BookService bookService = new BookService(repository);

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Показать все книги");
                Console.WriteLine("2. Найти книгу по ID");
                Console.WriteLine("3. Добавить книгу");
                Console.WriteLine("4. Обновить книгу");
                Console.WriteLine("5. Удалить книгу");
                Console.WriteLine("6. Поиск книг");
                Console.WriteLine("7. Выйти");
                Console.Write("Выберите пункт меню: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllBooks(bookService);
                        break;
                    case "2":
                        FindBookById(bookService);
                        break;
                    case "3":
                        AddBook(bookService);
                        break;
                    case "4":
                        UpdateBook(bookService);
                        break;
                    case "5":
                        DeleteBook(bookService);
                        break;
                    case "6":
                        SearchBooks(bookService);
                        break;
                    case "7":
                        if (ConfirmExit())
                        {
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void ShowAllBooks(BookService bookService)
        {
            var books = bookService.SearchBooks("");
            if (books.Count == 0)
            {
                Console.WriteLine("Список книг пуст.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        static void FindBookById(BookService bookService)
        {
            Console.Write("Введите ID книги: ");
            int id = int.Parse(Console.ReadLine());
            var book = bookService.SearchBooks("").ElementAtOrDefault(id);
            if (book != null)
            {
                Console.WriteLine(book);
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }

        static void AddBook(BookService bookService)
        {
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();
            Console.Write("Введите автора книги: ");
            string author = Console.ReadLine();
            Console.Write("Введите ISBN книги: ");
            string isbn = Console.ReadLine();
            Console.Write("Введите год издания книги: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Введите описание книги: ");
            string description = Console.ReadLine();

            Book book = new Book(title, author, isbn, year, description);
            bookService.AddBook(book);
            Console.WriteLine("Книга добавлена.");
        }

        static void UpdateBook(BookService bookService)
        {
            Console.Write("Введите ID книги для обновления: ");
            int id = int.Parse(Console.ReadLine());
            var book = bookService.SearchBooks("").ElementAtOrDefault(id);
            if (book != null)
            {
                Console.Write("Введите новое название книги: ");
                book.Title = Console.ReadLine();
                Console.Write("Введите нового автора книги: ");
                book.Author = Console.ReadLine();
                Console.Write("Введите новый ISBN книги: ");
                book.ISBN = Console.ReadLine();
                Console.Write("Введите новый год издания книги: ");
                book.Year = int.Parse(Console.ReadLine());
                Console.Write("Введите новое описание книги: ");
                book.Description = Console.ReadLine();

                bookService.UpdateBook(book);
                Console.WriteLine("Книга обновлена.");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }

        static void DeleteBook(BookService bookService)
        {
            Console.Write("Введите ID книги для удаления: ");
            int id = int.Parse(Console.ReadLine());
            bookService.DeleteBook(id);
            Console.WriteLine("Книга удалена.");
        }

        static void SearchBooks(BookService bookService)
        {
            Console.Write("Введите запрос для поиска книг: ");
            string query = Console.ReadLine();
            var books = bookService.SearchBooks(query);
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        static bool ConfirmExit()
        {
            Console.Write("Вы уверены, что хотите выйти? (да/нет): ");
            string response = Console.ReadLine().ToLower();
            return response == "да" || response == "y";
        }
    }
}