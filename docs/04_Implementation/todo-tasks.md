# TODO — Implementation Tasks

## 🗂 Project Setup
- [ ] Create WPF .NET 8 project structure
- [ ] Set up folders: Models, Views, ViewModels, Services, Repositories
- [ ] Create placeholder JSON file for book storage

## 📘 Book Features
- [ ] Implement `Book` model + `ReadingStatus` enum
- [ ] Create `IBookRepository` + `JsonBookRepository`
- [ ] Create `BookService` for core logic
- [ ] Implement `MainViewModel` with ObservableCollection<Book>
- [ ] Bind `MainWindow.xaml` to book list
- [ ] Add filtering and sorting controls

## 📝 Note Features
- [ ] Implement `Note` model
- [ ] Add notes to `Book` object
- [ ] Create `NoteService` and link to BookDetailView
- [ ] Implement adding and displaying notes

## 📋 Forms & Views
- [ ] Build Add/Edit Book Form
- [ ] Build Book Detail View
- [ ] Hook up navigation or view swapping logic

## 💾 Persistence
- [ ] Load JSON on startup
- [ ] Save to JSON on change
- [ ] Validate file structure on load

## 🎨 UI Polish
- [ ] Apply theme and spacing to match HTML prototype
- [ ] Add icons or decorative accents
