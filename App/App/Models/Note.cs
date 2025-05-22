using System;

namespace app.Models
{
    public class Note
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BookId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsFavorite { get; set; }

    }
}