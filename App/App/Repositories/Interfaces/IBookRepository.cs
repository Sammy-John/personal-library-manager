using PersonalLibraryApp.Models;

namespace PersonalLibraryApp.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(Guid id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}