# 🐛 Buggy Student CRUD — Practical Lab Activity

## ASP.NET Core MVC Bug Hunting Exercise

This is a **Student Records Management System** built with ASP.NET Core MVC and Entity Framework Core. It has been **intentionally coded with several bugs** for you to find and fix as part of your practical lab activity.

---

## 📋 Prerequisites

Before you begin, make sure you have the following installed on your machine:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (or .NET 9.0)
- A code editor — **Visual Studio 2022** (recommended), VS Code, or Rider
- [Git](https://git-scm.com/downloads)
- **SQL Server** — one of the following:
  - SQL Server LocalDB (comes with Visual Studio)
  - SQL Server Express
  - Full SQL Server instance
- **SQL Server Management Studio (SSMS)** or **Azure Data Studio** — for creating and viewing your database
- EF Core CLI tool (install via terminal):
  ```bash
  dotnet tool install --global dotnet-ef
  ```

---

## 🚀 Getting Started

### Step 1: Clone the Repository

```bash
git clone https://github.com/mahmenxx/BuggyStudentCRUD.git
cd BuggyStudentCRUD
```

### Step 2: Create the Database

> ⚠️ **You are required to create the database yourself.** This is part of the practical exercise.

Open `appsettings.json` inside the `BuggyStudentCRUD` project folder — this file contains all the clues you need:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=________;..."
}
```

📌 **Look at the connection string carefully.** The `Database=` value tells you **exactly what database name to create**.

**To create the database:**

1. Open **SQL Server Management Studio (SSMS)** or **Azure Data Studio**
2. Connect to your SQL Server instance:
   - If using LocalDB: connect to `(localdb)\mssqllocaldb`
   - If using SQL Server Express: connect to `.\SQLEXPRESS` or `YOUR_PC_NAME\SQLEXPRESS`
3. Right-click on **Databases** → **New Database...**
4. Enter the database name **exactly as it appears** in `appsettings.json`
5. Click **OK**

> 💡 **Tip:** If you're using SQL Server Express or a named instance instead of LocalDB, you'll also need to update the `Server=` value in `appsettings.json` to match your setup (e.g., `Server=.\SQLEXPRESS`).

### Step 3: Create the Table

You have **two options** — pick whichever works for you:

#### Option A: Run the Scaffold Script (automatic)

```bash
scaffold.bat
```

This will restore packages, install the correct EF Core tool version, create migration files, and apply them to your database.

#### Option B: Use Package Manager Console in Visual Studio (if scaffold.bat doesn't work)

If you run into issues with the scaffold script, open **Visual Studio** and go to **Tools → NuGet Package Manager → Package Manager Console**, then run:

```powershell
Add-Migration InitialCreate
Update-Database
```

> 💡 Make sure the **Default project** dropdown in the Package Manager Console is set to `BuggyStudentCRUD`.

#### Option C: Create the Table Manually in SSMS (last resort)

If neither option above works, you can create the table yourself. Run this SQL script in SSMS against your database:

```sql
CREATE TABLE [Students] (
    [Id]             INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [FirstName]      NVARCHAR(50)   NOT NULL,
    [LastName]       NVARCHAR(50)   NOT NULL,
    [Email]          NVARCHAR(MAX)  NOT NULL,
    [Course]         NVARCHAR(100)  NOT NULL,
    [YearLevel]      INT            NOT NULL,
    [GPA]            FLOAT          NOT NULL,
    [EnrollmentDate] DATETIME2      NOT NULL
);

-- Sample data so you have students to test with
INSERT INTO [Students] ([FirstName], [LastName], [Email], [Course], [YearLevel], [GPA], [EnrollmentDate])
VALUES
    ('Maria',    'Santos',    'maria.santos@university.edu',    'Computer Science',       3, 3.5, '2023-08-15'),
    ('Juan',     'Dela Cruz', 'juan.delacruz@university.edu',   'Information Technology',  2, 3.2, '2024-01-10'),
    ('Ana',      'Reyes',     'ana.reyes@university.edu',       'Computer Science',        4, 3.8, '2022-06-20'),
    ('Carlos',   'Garcia',    'carlos.garcia@university.edu',   'Information Systems',     1, 2.9, '2025-08-01'),
    ('Patricia', 'Lim',       'patricia.lim@university.edu',    'Computer Engineering',    3, 3.6, '2023-08-15');
```

> 📌 Make sure you run this on the correct database (the one you created in Step 2).

### Step 4: Run the Application

```bash
cd BuggyStudentCRUD
dotnet run
```

The app will start on `https://localhost:5001` or `http://localhost:5000`. Open it in your browser.

> **Note:** Five sample students are seeded automatically on first run. If you don't see any students, check the Troubleshooting section below.

---

## 🎯 Your Task

This application contains **7 bugs** spread across the **Model**, **Views**, and **Controllers**. Your job is to:

1. **Set up** the project and database by following the steps above
2. **Run the application** and test every feature
3. **Identify each bug** by observing unexpected behavior
4. **Fix each bug** in the source code


### Features to Test

| Feature | What to Test |
|---------|-------------|
| **Student List** | Does the search bar work? Can you sort by columns? |
| **View Details** | Click on a student — does it show the correct info? |
| **Create Student** | Fill in all fields with valid data and submit. Does it save? |
| **Edit Student** | Modify a student's information. Does it update properly? |
| **Delete Student** | Remove a student. Is it actually deleted? |
| **Validation** | Try entering invalid data (empty fields, out-of-range GPA). What happens? |

### 💡 Hints

- Bugs are in the **Controller logic**, **View templates**, and **Model/View validation**
- Pay close attention to what happens vs. what *should* happen
- Use the browser's developer tools (F12) to inspect network requests if needed
- Read error messages carefully — they often point to the root cause
- Compare the code to what standard CRUD operations should look like
- Look at **operators**, **method names**, and **conditional logic** closely

---

## 📁 Project Structure

```
BuggyStudentCRUD/
├── Controllers/
│   ├── HomeController.cs          # Home page controller
│   └── StudentsController.cs      # Student CRUD operations
├── Data/
│   ├── ApplicationDbContext.cs     # EF Core database context
│   └── SeedData.cs                # Sample data seeder
├── Models/
│   ├── Student.cs                 # Student entity with validation
│   └── ErrorViewModel.cs          # Error view model
├── Views/
│   ├── Home/                      # Home page views
│   ├── Students/                  # Student CRUD views
│   └── Shared/                    # Layout and shared views
├── wwwroot/                       # Static files (CSS, JS)
├── Program.cs                     # App entry point & DB setup
├── appsettings.json               # 🔑 Configuration — YOUR CLUE for the DB name!
└── scaffold.bat                   # Database migration script
```

---


## ⚠️ Important Notes

- **DO NOT** look at the git blame or commit messages for hints about the bugs
- Work **individually** unless your instructor says otherwise
- Make sure you've **created the database** and run `scaffold.bat` before running the application
- If the app crashes, read the exception message — it's a clue!
- There are exactly **7 bugs** — keep looking until you find them all

---

## 🛠 Tech Stack

- **Framework:** ASP.NET Core 8.0 MVC
- **ORM:** Entity Framework Core 8.0 (SQL Server)
- **Frontend:** Bootstrap 5, Font Awesome 6
- **Language:** C# 10

---

## 🔧 Troubleshooting

**The connection string doesn't match my SQL Server setup.**
If you're not using LocalDB, update the `Server` value in `appsettings.json`:
- SQL Server Express: `Server=.\SQLEXPRESS` or `Server=YOUR_PC_NAME\SQLEXPRESS`
- Full SQL Server: `Server=YOUR_PC_NAME` or `Server=localhost`

**How do I check if LocalDB is installed?**
```bash
sqllocaldb info
```
You should see `MSSQLLocalDB` listed. If not, install it via the Visual Studio Installer under **Individual Components → SQL Server Express LocalDB**.

**`dotnet-ef` is not recognized.**
```bash
dotnet tool install --global dotnet-ef
```
Close and reopen your terminal afterward.

**The scaffold script says "migration already exists."**
Delete the existing Migrations folder and try again:
```bash
rmdir /s /q BuggyStudentCRUD\Migrations
scaffold.bat
```

**How do I reset the database and start fresh?**
Run from the `BuggyStudentCRUD` project folder:
```bash
dotnet ef database drop --force
dotnet ef database update
```
The seed data will be re-inserted on the next app run.

**How do I view the database tables and data?**
Connect to your SQL Server using SSMS or Azure Data Studio and look for the database you created. You should see a `Students` table under **Tables**.

**The app runs but no students appear.**
This could be one of the bugs — or the database might not have been seeded. Try resetting the database (see above). If students still don't appear, investigate the controller code — that's a hint! 😉

---

Good luck and happy debugging! 🔍
