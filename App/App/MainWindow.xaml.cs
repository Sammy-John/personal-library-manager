using PersonalLibraryApp.Repositories.Json;
using PersonalLibraryApp.Services;
using PersonalLibraryApp.ViewModels;
using System.IO;
using System.Windows;


namespace PersonalLibraryApp.Views
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