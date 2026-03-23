using BuggyStudentCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BuggyStudentCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;
    }
}
