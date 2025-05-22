# Use Cases — Personal Library Manager

---

### UC1: Add a New Book

**Actor:** User  
**Goal:** Add a new book to their personal collection  
**Preconditions:** The application is running  
**Postconditions:** The new book appears in the library list

**Main Flow:**
1. User clicks “Add Book”
2. System presents a form to enter book details
3. User fills in title, author, ISBN, genre, etc.
4. User clicks “Save”
5. System validates and stores the book in the JSON file
6. System refreshes the book list

---

### UC2: Edit Book Details

**Actor:** User  
**Goal:** Update information for an existing book  
**Preconditions:** The book exists in the collection  
**Postconditions:** Book data is updated in storage and UI

**Main Flow:**
1. User selects a book and clicks “Edit”
2. System loads existing details into a form
3. User updates one or more fields
4. User clicks “Save”
5. System writes the changes to storage
6. UI updates with new values

---

### UC3: Track Reading Progress

**Actor:** User  
**Goal:** Update current reading status and page number  
**Preconditions:** The book exists in the system  
**Postconditions:** Reading progress is saved and visible

**Main Flow:**
1. User selects a book
2. System displays progress tracking fields
3. User updates page/chapter or status
4. User confirms/save
5. System writes changes to file and updates UI

---

### UC4: Add a Note or Review

**Actor:** User  
**Goal:** Record thoughts or notes about a book  
**Preconditions:** Book exists in the system  
**Postconditions:** Note is saved and associated with that book

**Main Flow:**
1. User selects a book and clicks “Add Note”
2. System opens a text input area
3. User writes and saves a note
4. System stores the note in JSON under that book
5. UI shows the note in the book’s detail view

---

### UC5: Filter and Sort Books

**Actor:** User  
**Goal:** View books in a desired order or subset  
**Preconditions:** The user has added multiple books  
**Postconditions:** A filtered/sorted view of the list is shown

**Main Flow:**
1. User selects filter/sort options from dropdowns
2. System reorders or filters the book list in the UI
3. No changes are made to stored data

