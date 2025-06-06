﻿using System.IO;
using System.Windows;
using PersonalLibraryApp.Models;
using PersonalLibraryApp.Repositories.Json;
using PersonalLibraryApp.Services;
using PersonalLibraryApp.ViewModels;
using PersonalLibraryApp.Views; // Needed for AddBookView
using PersonalLibraryApp.Views.Components;
using PersonalLibraryApp.Helpers;

namespace PersonalLibraryApp.Views
{
    public partial class MainWindow : Window
    {
        private readonly JsonBookRepository _bookRepo;
        private readonly BookService _bookService;
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            try
            {
                string solutionRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\.."));
                string dataPath = Path.Combine(solutionRoot, "Data", "bookData.json");

                Directory.CreateDirectory(Path.GetDirectoryName(dataPath)!);
                if (!File.Exists(dataPath))
                    File.WriteAllText(dataPath, "[]");

                _bookRepo = new JsonBookRepository(dataPath);
                _bookService = new BookService(_bookRepo);
                _viewModel = new MainViewModel(_bookService);

                InitializeComponent();
                DataContext = _viewModel;

                if (FindName("BookTable") is BookTableView tableView)
                {
                    tableView.Books = _viewModel.Books;
                    tableView.ViewBookRequested += ViewBook_Click;
                    tableView.EditBookRequested += EditBook_Click;
                    tableView.DeleteBookRequested += DeleteBook_Click;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup Exception:\n{ex.GetType().Name}\n{ex.Message}", "Startup Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
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

        private async void EditBook_Click(Book selectedBook)
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

        private async void DeleteBook_Click(Book selectedBook)
        {
            if (MessageBox.Show($"Delete '{selectedBook.Title}'?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                await _bookService.DeleteBookAsync(selectedBook.Id);
                await _viewModel.ReloadBooksAsync();
            }
        }

        private async void ViewBook_Click(Book selectedBook)
        {
            var noteRepo = new JsonNoteRepository(_bookRepo);
            var detailWindow = new BookDetailView(selectedBook, noteRepo) { Owner = this };

            if (detailWindow.ShowDialog() == true)
            {
                await _bookService.UpdateBookAsync(detailWindow.Book);
                await _viewModel.ReloadBooksAsync();
            }
        }
    }
}
