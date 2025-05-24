using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using PersonalLibraryApp.Models;
using PersonalLibraryApp.Repositories.Interfaces;

namespace PersonalLibraryApp.Views
{
    public partial class BookDetailView : Window
    {
        public Book Book { get; private set; }
        private readonly INoteRepository _noteRepository;

        public BookDetailView(Book book, INoteRepository noteRepository)
        {
            InitializeComponent();
            _noteRepository = noteRepository;
            Book = book;

            LoadNotesAsync().ConfigureAwait(false);
            DataContext = this;
        }

        private async Task LoadNotesAsync()
        {
            var notes = await _noteRepository.GetNotesByBookIdAsync(Book.Id);
            Book.Notes = new List<Note>(notes);
            RefreshBinding();
        }

        private async void AddNote_Click(object sender, RoutedEventArgs e)
        {
            var text = Microsoft.VisualBasic.Interaction.InputBox("Enter your note:", "Add Note", "");
            if (!string.IsNullOrWhiteSpace(text))
            {
                var newNote = new Note
                {
                    Id = Guid.NewGuid(),
                    BookId = Book.Id,
                    Content = text,
                    CreatedDate = DateTime.Now
                };

                await _noteRepository.AddNoteAsync(newNote);
                await _noteRepository.SaveChangesAsync();
                await LoadNotesAsync();
            }
        }

        private async void EditNote_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.Tag is Note note)
            {
                var newText = Microsoft.VisualBasic.Interaction.InputBox("Edit note:", "Edit Note", note.Content);
                if (!string.IsNullOrWhiteSpace(newText))
                {
                    note.Content = newText;
                    await _noteRepository.UpdateNoteAsync(note);
                    await _noteRepository.SaveChangesAsync();
                    await LoadNotesAsync();
                }
            }
        }

        private async void DeleteNote_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.Tag is Note note)
            {
                if (MessageBox.Show("Delete this note?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    await _noteRepository.DeleteNoteAsync(note.Id);
                    await _noteRepository.SaveChangesAsync();
                    await LoadNotesAsync();
                }
            }
        }

        private void RefreshBinding()
        {
            DataContext = null;
            DataContext = this;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
