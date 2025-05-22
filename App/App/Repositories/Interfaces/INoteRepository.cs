using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Models;

namespace app.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> GetNotesByBookIdAsync (Guid bookId);
        Task AddNoteAsync(Note note);
        Task UpdateNoteAsync(Note note);
        Task DeleteNoteAsync(Guid noteId);
        Task SaveChangesAsync();

    }
}