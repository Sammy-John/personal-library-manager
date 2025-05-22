using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Models;

namespace app.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllSync();
        Task<List<Book>> GetAllAsync();
        Task AddAsync (Book book);
        Task UpdateAsync (Book book);
        Task DeleteAsync (Guid id);
        Task SaveChangesAsync();
    
    }
}