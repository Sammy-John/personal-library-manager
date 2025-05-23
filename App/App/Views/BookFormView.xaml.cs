// BookFormView.xaml.cs
using PersonalLibraryApp.Models;
using System.Windows;

namespace PersonalLibraryApp.Views
{
    public partial class BookFormView : Window
    {
        public Book? BookResult { get; private set; }

        public BookFormView(Book? existingBook = null)
        {
            InitializeComponent();

            if (existingBook != null)
            {
                TitleBox.Text = existingBook.Title;
                AuthorBox.Text = existingBook.Author;
                GenreBox.Text = existingBook.Genre;

                BookResult = existingBook;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (BookResult == null)
                BookResult = new Book();

            BookResult.Title = TitleBox.Text;
            BookResult.Author = AuthorBox.Text;
            BookResult.Genre = GenreBox.Text;

            this.DialogResult = true;
            this.Close();
        }
    }
}
