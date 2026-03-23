using System.ComponentModel.DataAnnotations;

namespace BuggyStudentCRUD.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course is required")]
        [StringLength(100)]
        public string Course { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Year Level")]
        [Range(1, 6, ErrorMessage = "Year level must be between 1 and 6")]
        public int YearLevel { get; set; }

        [Required]
        [Display(Name = "GPA")]
        [Range(0, 5.0, ErrorMessage = "GPA must be between 0.0 and 5.0")]
        public double GPA { get; set; }

        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
