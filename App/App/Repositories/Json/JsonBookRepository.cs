using PersonalLibraryApp.Models;
using PersonalLibraryApp.Repositories.Interfaces;
using System.IO;
using System.Text.Json;

namespace PersonalLibraryApp.Repositories.Json

{
    public class JsonBookRepository : IBookRepository
    {
        private readonly string _filePath;
        private List<Book> _books = new();

        public JsonBookRepository(string filePath)
        {
            _filePath = filePath;
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _books = JsonSerializer.Deserialize<List<Book>>(json) ?? new();
            }
        }

        private void SaveToFile()
        {
            string json = JsonSerializer.Serialize(_books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public Task<List<Book>> GetAllAsync() => Task.FromResult(_books);

        public Task<Book?> GetByIdAsync(Guid id) =>
            Task.FromResult(_books.FirstOrDefault(b => b.Id == id));

        public Task AddAsync(Book book)
        {
            _books.Add(book);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Book book)
        {
            var index = _books.FindIndex(b => b.Id == book.Id);
            if (index >= 0)
                _books[index] = book;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _books.RemoveAll(b => b.Id == id);
            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            SaveToFile();
            return Task.CompletedTask;
        }
    }
}
