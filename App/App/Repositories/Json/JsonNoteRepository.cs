using PersonalLibraryApp.Models;
using PersonalLibraryApp.Repositories.Interfaces;

namespace PersonalLibraryApp.Repositories.Json
{
    public class JsonNoteRepository : INoteRepository
    {
        private readonly IBookRepository _bookRepo;

        public JsonNoteRepository(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task<List<Note>> GetNotesByBookIdAsync(Guid bookId)
        {
            var book = await _bookRepo.GetByIdAsync(bookId);
            return book?.Notes ?? new List<Note>();
        }

        public async Task AddNoteAsync(Note note)
        {
            var book = await _bookRepo.GetByIdAsync(note.BookId);
            book?.Notes.Add(note);
        }

        public async Task UpdateNoteAsync(Note note)
        {
            var book = await _bookRepo.GetByIdAsync(note.BookId);
            if (book == null) return;

            var index = book.Notes.FindIndex(n => n.Id == note.Id);
            if (index >= 0) book.Notes[index] = note;
        }

        public async Task DeleteNoteAsync(Guid noteId)
        {
            var allBooks = await _bookRepo.GetAllAsync();
            foreach (var book in allBooks)
            {
                book.Notes.RemoveAll(n => n.Id == noteId);
            }
        }

        public Task SaveChangesAsync() => _bookRepo.SaveChangesAsync(); // rely on shared JSON
    }
}
