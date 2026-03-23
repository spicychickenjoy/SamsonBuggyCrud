@echo off
echo ==========================================
echo  BuggyStudentCRUD - Database Setup Script
echo ==========================================
echo.

cd /d "%~dp0BuggyStudentCRUD"

echo [1/4] Restoring NuGet packages...
dotnet restore
if %ERRORLEVEL% NEQ 0 (
    echo ERROR: Failed to restore packages.
    pause
    exit /b 1
)
echo.

echo [2/4] Restoring local EF Core tool (v6.0.25)...
dotnet tool restore
if %ERRORLEVEL% NEQ 0 (
    echo ERROR: Failed to restore dotnet-ef tool.
    pause
    exit /b 1
)
echo.

echo [3/4] Creating initial migration...
dotnet dotnet-ef migrations add InitialCreate
if %ERRORLEVEL% NEQ 0 (
    echo ERROR: Failed to create migration.
    pause
    exit /b 1
)
echo.

echo [4/4] Applying migration to database...
dotnet dotnet-ef database update
if %ERRORLEVEL% NEQ 0 (
    echo ERROR: Failed to update database.
    pause
    exit /b 1
)
echo.

echo ==========================================
echo  Database setup complete!
echo  Database: BuggyStudentCRUDDb
echo ==========================================
pause
