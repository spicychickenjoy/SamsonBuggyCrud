using BuggyStudentCRUD.Models;

namespace BuggyStudentCRUD.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Students.Any())
                return;

            context.Students.AddRange(
                new Student
                {
                    FirstName = "Maria",
                    LastName = "Santos",
                    Email = "maria.santos@university.edu",
                    Course = "Computer Science",
                    YearLevel = 3,
                    GPA = 3.5,
                    EnrollmentDate = new DateTime(2023, 8, 15)
                },
                new Student
                {
                    FirstName = "Juan",
                    LastName = "Dela Cruz",
                    Email = "juan.delacruz@university.edu",
                    Course = "Information Technology",
                    YearLevel = 2,
                    GPA = 3.2,
                    EnrollmentDate = new DateTime(2024, 1, 10)
                },
                new Student
                {
                    FirstName = "Ana",
                    LastName = "Reyes",
                    Email = "ana.reyes@university.edu",
                    Course = "Computer Science",
                    YearLevel = 4,
                    GPA = 3.8,
                    EnrollmentDate = new DateTime(2022, 6, 20)
                },
                new Student
                {
                    FirstName = "Carlos",
                    LastName = "Garcia",
                    Email = "carlos.garcia@university.edu",
                    Course = "Information Systems",
                    YearLevel = 1,
                    GPA = 2.9,
                    EnrollmentDate = new DateTime(2025, 8, 1)
                },
                new Student
                {
                    FirstName = "Patricia",
                    LastName = "Lim",
                    Email = "patricia.lim@university.edu",
                    Course = "Computer Engineering",
                    YearLevel = 3,
                    GPA = 3.6,
                    EnrollmentDate = new DateTime(2023, 8, 15)
                }
            );

            context.SaveChanges();
        }
    }
}
