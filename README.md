# Enterprise Blog & Content Management System (CMS) 📝

An end-to-end content management platform built with an ASP.NET Core MVC backend, SQL Server, and dynamic React.js UI components. Designed using clean architecture principles including the Repository Pattern and Dependency Injection.

## 🚀 Tech Stack
* **Backend:** C#, ASP.NET Core MVC (.NET 8.0), Entity Framework Core (Code-First)
* **Frontend:** React.js (Dynamic Search & Category Filtering), Razor Views, HTML5, CSS3, Bootstrap 5
* **Database:** MS SQL Server, LINQ
* **Architecture & Security:** Repository Pattern, Dependency Injection (DI), Cookie Authentication, Role-Based Authorization (`Admin` / `Author`), BCrypt Password Hashing

## ✨ Key Features
* **Dynamic React.js Feed:** Real-time article search and category filtering powered by React hooks (`useState`, `useEffect`) consuming a JSON API endpoint (`/api/articles`).
* **Role-Based Access Control:** Secure authentication workflow allowing authenticated Authors to publish articles and Admins to manage/delete content.
* **Clean Architecture:** Decoupled data access layer using `IArticleRepository` and `ArticleRepository` injected via ASP.NET Core DI container.
* **High-Throughput CRUD Workflows:** Seamless article publishing, categorization (`Technology`, `Architecture`, `Cloud & AI`), and content management.

## ⚙️ How to Run Locally
1. Clone the repository.
2. Update the SQL Server connection string in `appsettings.json`.
3. Open **Package Manager Console** in Visual Studio and run:
   ```powershell
   Update-Database
