using System.IO;
using System.Windows;
using PersonalLibraryApp.Models;
using PersonalLibraryApp.Repositories.Json;
using PersonalLibraryApp.Services;
using PersonalLibraryApp.ViewModels;
using PersonalLibraryApp.Views; // Needed for AddBookView

namespace PersonalLibraryApp.Views
{
    public partial class MainWindow : Window
    {
        private readonly BookService _bookService;
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            // Setup data source
            var dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "bookData.json");
            var bookRepo = new JsonBookRepository(dataPath);
            _bookService = new BookService(bookRepo);
            _viewModel = new MainViewModel(_bookService);
            DataContext = _viewModel;
        }

        private async void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new BookFormView { Owner = this };
            if (addWindow.ShowDialog() == true && addWindow.BookResult != null)
            {
                await _bookService.AddBookAsync(addWindow.BookResult);
                await _viewModel.ReloadBooksAsync();
            }
        }

        private async void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.Tag is Book selectedBook)
            {
                var form = new BookFormView(new Book
                {
                    Id = selectedBook.Id,
                    Title = selectedBook.Title,
                    Author = selectedBook.Author,
                    Genre = selectedBook.Genre,
                    Status = selectedBook.Status,
                    Rating = selectedBook.Rating,
                    CurrentPage = selectedBook.CurrentPage,
                    LastReadDate = selectedBook.LastReadDate,
                    Tags = new List<string>(selectedBook.Tags),
                    Notes = new List<Note>(selectedBook.Notes)
                })
                { Owner = this };

                if (form.ShowDialog() == true && form.BookResult != null)
                {
                    await _bookService.UpdateBookAsync(form.BookResult);
                    await _viewModel.ReloadBooksAsync();
                }
            }
        }

        private async void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.Tag is Book selectedBook)
            {
                if (MessageBox.Show($"Delete '{selectedBook.Title}'?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    await _bookService.DeleteBookAsync(selectedBook.Id);
                    await _viewModel.ReloadBooksAsync();
                }
            }
        }

    }
}
