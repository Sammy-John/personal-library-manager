using PersonalLibraryApp.Models;
using PersonalLibraryApp.Repositories.Interfaces;

namespace PersonalLibraryApp.Services


{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<List<Book>> GetAllBooksAsync() => _bookRepository.GetAllAsync();

        public Task<Book?> GetBookByIdAsync(Guid id) => _bookRepository.GetByIdAsync(id);

        public async Task AddBookAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book Book)
        {
            await _bookRepository.UpdateAsync(Book);
            await _bookRepository.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Guid Id)
        {
            await _bookRepository.DeleteAsync(Id);
            await _bookRepository.SaveChangesAsync();
        }
    }
}