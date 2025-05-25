// BookFormView.xaml.cs
using PersonalLibraryApp.Models;
using System.Windows;
using System.Windows.Controls;

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
                StatusBox.SelectedIndex = (int)existingBook.Status;
                CurrentPageBox.Text = existingBook.CurrentPage?.ToString() ?? "";
                LastReadDatePicker.SelectedDate = existingBook.LastReadDate;

                if (existingBook.Rating.HasValue)
                    RatingBox.SelectedIndex = existingBook.Rating.Value - 1;
                else
                    RatingBox.SelectedIndex = -1;

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
            BookResult.Status = (ReadingStatus)StatusBox.SelectedIndex;

            if (int.TryParse(CurrentPageBox.Text, out int page))
                BookResult.CurrentPage = page;
            else
                BookResult.CurrentPage = null;

            BookResult.LastReadDate = LastReadDatePicker.SelectedDate;

            if (RatingBox.SelectedItem is ComboBoxItem item &&
                int.TryParse(item.Content.ToString(), out int rating))
            {
                BookResult.Rating = rating;
            }
            else
            {
                BookResult.Rating = null;
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}
