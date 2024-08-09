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
using System.Windows.Shapes;

namespace WpfApp {

    public partial class AddBookWindow : Window
    {
        private BookService bookService;

        public AddBookWindow(BookService bookService)
        {
            InitializeComponent();
            this.bookService = bookService;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleBox.Text;
            string author = AuthorBox.Text;
            string isbn = ISBNBox.Text;
            int year = int.Parse(YearBox.Text);
            string description = DescriptionBox.Text;

            Book book = new Book(title, author, isbn, year, description);
            bookService.AddBook(book);
            MessageBox.Show("Книга добавлена.");
            Close();
        }
    }
}
