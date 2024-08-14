using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookService bookService;

        public MainWindow()
        {
            InitializeComponent();
            IBookRepository repository = new FileBookRepositoryXML("books.xml");
            //IBookRepository repository = new MemoryBookRepository();
            bookService = new BookService(repository);
            LoadBooks();
        }

        private void LoadBooks()
        {
            BooksList.ItemsSource = bookService.SearchBooks("");
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchBox.Text;
            BooksList.ItemsSource = bookService.SearchBooks(query);
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            var addBookWindow = new AddBookWindow(bookService);
            addBookWindow.ShowDialog();
            LoadBooks();
        }

        private void UpdateBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksList.SelectedItem is Book selectedBook)
            {
                var updateBookWindow = new UpdateBookWindow(bookService, selectedBook);
                updateBookWindow.ShowDialog();
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Выберите книгу для обновления.");
            }
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksList.SelectedItem is Book selectedBook)
            {
                bookService.DeleteBook(bookService.SearchBooks("").IndexOf(selectedBook));
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Выберите книгу для удаления.");
            }
        }
    }
}
