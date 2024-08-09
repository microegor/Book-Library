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

namespace WpfApp
{
    public partial class UpdateBookWindow : Window
    {
        private BookService bookService;
        private Book book;

        public UpdateBookWindow(BookService bookService, Book book)
        {
            InitializeComponent();
            this.bookService = bookService;
            this.book = book;

            TitleBox.Text = book.Title;
            AuthorBox.Text = book.Author;
            ISBNBox.Text = book.ISBN;
            YearBox.Text = book.Year.ToString();
            DescriptionBox.Text = book.Description;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            book.Title = TitleBox.Text;
            book.Author = AuthorBox.Text;
            book.ISBN = ISBNBox.Text;
            book.Year = int.Parse(YearBox.Text);
            book.Description = DescriptionBox.Text;

            bookService.UpdateBook(book);
            MessageBox.Show("Книга обновлена.");
            Close();
        }
    }
}
