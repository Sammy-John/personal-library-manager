# Layered Architecture — Personal Library Manager

This document describes the layered architecture used in the Personal Library Manager WPF application. It follows a clean separation of concerns using the MVVM pattern, service and repository abstractions, and prepares for future extensibility (e.g., database integration).

---

## 🧱 Overview

The architecture consists of five logical layers:

1. **Presentation Layer** — WPF Views
2. **ViewModel Layer** — MVVM binding logic and UI coordination
3. **Service Layer** — Business logic and rule enforcement
4. **Repository Layer** — Abstracted data access via interfaces
5. **Data/Storage Layer** — Actual file or database handling (JSON or SQLite)

Each layer depends only on the one below it, ensuring maintainability, testability, and scalability.

---

## 1. Presentation Layer

- Built using **WPF Views (.xaml)**.
- Responsible for defining UI layout, bindings, and event triggers.
- Contains no logic — purely visual and declarative.

**Example:**  
`MainWindow.xaml`, `BookDetailView.xaml`

---

## 2. ViewModel Layer

- Implements the **MVVM pattern**.
- Coordinates data between UI and services.
- Implements `INotifyPropertyChanged` and command binding.
- Manually injected with services via constructor.

**Example:**  
`MainViewModel`, `BookDetailViewModel`

---

## 3. Service Layer

- Encapsulates business rules and core logic.
- Orchestrates operations like creating, updating, or filtering books.
- Keeps ViewModels thin and focused on presentation concerns.

**Example:**  
`BookService`, `NoteService`

---

## 4. Repository Layer

- Defines interfaces and concrete classes for data persistence.
- Uses the **Repository Pattern** to abstract the storage mechanism (JSON now, database later).
- Follows **Dependency Inversion Principle**.

**Example:**  
- `IBookRepository`, `INoteRepository`
- `JsonBookRepository` (current)
- `SqlBookRepository` (future)

---

## 5. Data/Storage Layer

- Responsible for physical data persistence.
- For MVP: stores data in a **local JSON file**.
- Future versions will migrate to a **SQLite database** via EF Core or custom data access.

**Example:**  
`bookData.json`, or `library.db` (planned)

---

## 🔁 Data Flow Summary

```plaintext
User ↔ View (XAML)
       ↓
ViewModel
       ↓
Service
       ↓
Repository Interface
       ↓
Concrete JSON/DB Storage
```

---

## 🔧 Dependency Management

- The system uses **manual constructor injection** for now.
- A DI container (e.g., `Microsoft.Extensions.DependencyInjection`) may be introduced in future versions for automatic wiring and testing.

---

## ✅ Benefits

- Clean separation of concerns
- Prepares for replacing JSON with SQL without changing UI or ViewModels
- Modular and maintainable for long-term use
- Aligns with MVVM, SOLID, and testable architecture practices
