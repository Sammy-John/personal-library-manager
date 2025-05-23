using PersonalLibraryApp.Models;

namespace PersonalLibraryApp.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> GetNotesByBookIdAsync(Guid bookId);
        Task AddNoteAsync(Note note);
        Task UpdateNoteAsync(Note note);
        Task DeleteNoteAsync(Guid noteId);
        Task SaveChangesAsync();

    }
}