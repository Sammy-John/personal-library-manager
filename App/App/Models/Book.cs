namespace PersonalLibraryApp.Models

{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public ReadingStatus Status { get; set; } = ReadingStatus.NotStarted;
        public int? Rating { get; set; }
        public int? CurrentPage { get; set; }
        public DateTime? LastReadDate { get; set; }
        public List<string> Tags { get; set; } = new();
        public List<Note> Notes { get; set; } = new();

    }
}