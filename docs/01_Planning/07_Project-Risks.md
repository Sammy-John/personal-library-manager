# Project Risks — Personal Library Manager

This document outlines potential risks that may impact the development or success of the Personal Library Manager application, along with suggested mitigation strategies.

---

## 🧑‍💻 1. Solo Development Bottleneck

- **Risk**: As a solo developer, progress may stall due to time constraints, distractions, or burnout.
- **Mitigation**: Break work into small, achievable milestones. Use scoped phases (e.g., MVP, polish, enhancements). Prioritize momentum over perfection.

---

## 🗃 2. Data Persistence Limitations (JSON-only)

- **Risk**: Using only a local JSON file may limit scalability, performance, or data integrity as the book list grows.
- **Mitigation**: Structure JSON clearly from the start. Plan future upgrade path to SQLite without rewriting business logic (e.g., use a repository pattern from day one).

---

## 🧪 3. Feature Creep

- **Risk**: Adding too many future features (API, image previews, stats) may delay or bloat the MVP.
- **Mitigation**: Clearly separate MVP from future enhancements in roadmap. Use toggles or branches to experiment without disrupting core functionality.

---

## 💡 4. UI/UX Complexity

- **Risk**: Aiming for a highly polished UX/UI experience may lead to design indecision or excessive rework.
- **Mitigation**: Start with a simple, clean layout using WPF best practices. Document UI goals and stick to a consistent visual style.

---

## 🧪 5. Limited Real-World Testing

- **Risk**: Since the app is initially built for personal use, edge cases or usability issues may go unnoticed.
- **Mitigation**: Simulate various book types and edge cases (e.g., no author, multiple genres, long notes). Invite feedback if the app is shared later.

---

## 🔄 6. Technology Lock-in

- **Risk**: Choosing WPF and JSON may limit long-term portability or reuse.
- **Mitigation**: Follow a modular, layered architecture to allow reusing core logic with other UIs (e.g., Blazor, mobile) in the future.

