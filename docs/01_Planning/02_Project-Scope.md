# Project Scope — Personal Library Manager

## 1. In-Scope Features (MVP)

The following features will be included in the initial version of the application:

- Add, edit, and delete books
- Store and view reviews and notes for each book
- Filter and search books by various criteria (e.g., genre, read status, title)
- Record reading progress (e.g., last read date, current page)
- Autofill book details using ISBN where possible

## 2. Optional Features (Future Considerations)

These features are desirable but not required for the MVP:

- Integration with an external book API (e.g., Google Books) to autofill data from ISBN
- Support for book cover images or previews
- Reading statistics (e.g., total books read, average rating)
- Export/import collection to a file format
- Tagging system for more granular classification

## 3. Out-of-Scope Features

The following items are explicitly excluded from the initial release:

- Online features such as cloud sync, sharing, or remote access
- Multi-user support or user authentication
- Mobile or cross-platform versions (e.g., Android/iOS)
- Support for other media types (e.g., movies, PDFs, audiobooks)

## 4. Functional Boundaries

- The application is designed for **offline, personal use only**
- All data will be stored **locally** on the user's machine using a **JSON file** for the MVP
- A database-backed implementation (e.g., SQLite) may be considered in future versions
- No login, registration, or authentication will be implemented in the MVP

## 5. Platform and Technical Scope

- The application will be developed as a **Windows Desktop app using WPF and .NET 8**
- No third-party frameworks are required initially; any dependencies will be evaluated on a case-by-case basis based on usefulness and maintainability

## 6. Scope Limitations

This project will **only manage books**. While audiobooks may be considered for future support, the MVP is strictly limited to physical or digital books with ISBN tracking and user-generated notes.

