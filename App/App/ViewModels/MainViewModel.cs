using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using app.Models;
using app.Services;

namespace app.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly BookService _bookService;

        public ObservableCollection<Book> Books { get; set; } = new();

        public MainViewModel(BookService bookService)
        {
            _bookService = bookService;
            _ = LoadBooksAsync();
        }

        private async Task LoadBooksAsync()
        {
            var books = await _bookService.GetAllBooksAsync();
            Books.Clear();
            foreach (var book in books)
                Books.Add(book);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
