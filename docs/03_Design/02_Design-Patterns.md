# Design Patterns — Personal Library Manager

This document outlines the software design patterns used in the application architecture, including their purpose and specific implementation within the system. These patterns contribute to maintainability, extensibility, and adherence to SOLID principles.

---

## 🧱 1. MVVM (Model-View-ViewModel)

- **Purpose:** Separates UI (View) from logic (ViewModel) and data (Model)
- **Usage:** Core architectural pattern in all WPF views
- **Examples:**
  - `MainWindow.xaml` → `MainViewModel`
  - `BookDetailView.xaml` → `BookDetailViewModel`

---

## 🗂 2. Repository Pattern

- **Purpose:** Abstracts the data access logic and separates it from business logic
- **Usage:** Enables swapping JSON with a future SQL implementation
- **Examples:**
  - `IBookRepository` → interface
  - `JsonBookRepository` → current implementation
  - `SqlBookRepository` → planned replacement

---

## ⚙️ 3. Service Layer Pattern

- **Purpose:** Centralizes business logic and domain rules
- **Usage:** Keeps ViewModels lightweight and delegates logic to services
- **Examples:**
  - `BookService`, `NoteService` handle all operations related to books and notes

---

## 🧰 4. Factory Pattern (Planned)

- **Purpose:** Create objects (e.g., Book, Note) in a centralized way, especially when using external sources like APIs
- **Planned Usage:** When integrating Google Books API or loading structured data
- **Future Example:**
  - `BookFactory.CreateFromApiResult(json)`

---

## 🧪 5. Dependency Injection (Manual)

- **Purpose:** Decouple class dependencies for easier testing and substitution
- **Usage:** Services and repositories are injected manually into ViewModels
- **Examples:**
  - `MainViewModel(BookService service)`
  - Will evolve into automatic DI using `.NET DI` framework in later phases

---

## 🧠 Summary

| Pattern        | Benefit                        | Status     |
|----------------|--------------------------------|------------|
| MVVM           | Clean UI separation            | ✅ Active   |
| Repository     | Swap data source easily        | ✅ Active   |
| Service Layer  | Centralize logic               | ✅ Active   |
| Factory        | Decouple object creation       | 🕓 Planned  |
| Dependency Injection | Testability, flexibility | ✅ Manual   |

