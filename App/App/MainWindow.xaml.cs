using System.IO;
using System.Windows;
using app.Repositories.Json;
using app.Services;
using app.ViewModels;

namespace app.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "bookData.json");
            var bookRepo = new JsonBookRepository(dataPath);
            var bookService = new BookService(bookRepo);
            DataContext = new MainViewModel(bookService);
        }
    }
}
