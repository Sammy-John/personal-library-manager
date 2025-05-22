# Class List — Personal Library Manager

This document defines the key domain classes that will be used in the system. These classes represent the core data model and will be used to generate a UML Class Diagram in the next design phase.

---

## 📘 Book

- **Attributes:**
  - `Id: Guid`
  - `Title: string`
  - `Author: string`
  - `ISBN: string`
  - `Genre: string`
  - `Status: ReadingStatus` *(enum)*
  - `Rating: int?`
  - `CurrentPage: int?`
  - `LastReadDate: DateTime?`
  - `Tags: List<string>`
  - `Notes: List<Note>`

- **Relationships:**
  - One `Book` → Many `Notes`

- **Description:**  
  Represents a single book in the user's library. Tracks metadata and progress.

---

## 📝 Note

- **Attributes:**
  - `Id: Guid`
  - `BookId: Guid`
  - `Content: string`
  - `CreatedDate: DateTime`
  - `IsFavorite: bool`

- **Relationships:**
  - Many `Notes` → One `Book`

- **Description:**  
  Represents a personal note, quote, or thought associated with a book.

---

## ⏱ ReadingStatus (enum)

- **Values:**
  - `NotStarted`
  - `Reading`
  - `Completed`

- **Description:**  
  Enum that defines the reading progress status of a book.

---

## 📅 ScheduledRead (Planned)

- **Attributes:**
  - `Id: Guid`
  - `BookId: Guid`
  - `PlannedDate: DateTime`
  - `Comment: string`

- **Relationships:**
  - Many `ScheduledReads` → One `Book`

- **Description:**  
  Represents a planned reading session. (Optional/future feature)

---

## 💾 Library (optional container)

- **Attributes:**
  - `Books: List<Book>`

- **Description:**  
  Top-level object for saving/loading the entire book collection from JSON.

