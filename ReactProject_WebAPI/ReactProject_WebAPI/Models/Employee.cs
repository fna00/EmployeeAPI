using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReactProject_WebAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name is required")] // Boş bırakılamaz.
        [StringLength(50, ErrorMessage = "First Name can't be longer than 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name can't be longer than 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)] // UI'da bir tarih seçici oluşturur.
        [Display(Name = "Date of Birth")]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone] // Telefon numarası formatında olmasını sağlar.
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Home Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Department ID is required")]
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [Display(Name = "Job Position")]
        public string Position { get; set; }

        [DataType(DataType.Currency)] // UI'da para birimi formatında gösterir.
        [Display(Name = "Salary")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
    }
}
