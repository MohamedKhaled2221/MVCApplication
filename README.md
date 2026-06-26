# 🏢 HR Management Dashboard

An **ASP.NET Core 8 MVC** web application for managing employees and departments, built with Clean Architecture, secure authentication, and a responsive UI.

---

## 📸 Overview

A full-featured HR Dashboard that enables organizations to manage their workforce efficiently — from employee records and department structure to attendance tracking and salary reports.

---

## ✨ Features

- 👤 **Employee Management** — Full CRUD operations (Create, Read, Update, Delete) for employee records
- 🏬 **Department Linking** — Every employee is assigned to a department
- 🔐 **Authentication & Authorization** — Secure login with ASP.NET Core Identity and role-based access control
- 🎨 **Responsive UI** — Built with Bootstrap, HTML, CSS, and JavaScript

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|------------|
| Framework | ASP.NET Core 8 MVC |
| Language | C# |
| ORM | Entity Framework Core |
| Database | Microsoft SQL Server |
| Authentication | ASP.NET Core Identity + JWT |
| Validation | FluentValidation |
| Frontend | HTML, CSS, Bootstrap, JavaScript |
| Architecture | Clean Architecture, N-Tier |
| Version Control | Git & GitHub |

---

## 🏗️ Architecture

```
HRDashboard/
├── Core/
│   ├── Entities/          # Employee, Department
│   ├── Interfaces/        # Repository contracts
│   └── DTOs/              # Data Transfer Objects
├── Infrastructure/
│   ├── Data/              # AppDbContext, Migrations
│   ├── Repositories/      # EF Core implementations
│   └── Identity/          # ASP.NET Core Identity setup
├── Application/
│   └── Services/          # Business logic layer
└── Presentation/
    ├── Controllers/        # EmployeesController, DepartmentsController
    └── Views/             # Razor Views + Bootstrap UI
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/MohamedKhaled/HR-Dashboard.git
   cd HR-Dashboard
   ```

2. **Configure the database connection** in `appsettings.json`
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=HRDashboardDb;Trusted_Connection=True;"
     }
   }
   ```

3. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. Open your browser at `https://localhost:5001`

## 📂 Key Modules

### 👤 Employee Module
- **Create** a new employee and assign them to a department
- **View** all employees with their department info
- **Update** employee details
- **Delete** an employee record

### 🏬 Department Module
- View all available departments
- Each employee is linked to one department via a foreign key relationship

---

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/your-feature`
3. Commit your changes: `git commit -m "Add: your feature description"`
4. Push to the branch: `git push origin feature/your-feature`
5. Open a Pull Request

---

## 👨‍💻 Author

**Mohamed Khaled Amer**  
Full Stack .NET Developer  
📧 amer31824@gmail.com  
