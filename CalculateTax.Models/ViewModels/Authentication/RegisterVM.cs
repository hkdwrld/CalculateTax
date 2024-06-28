using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CalculateTax.Models.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string? ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Key]
        public string? Email { get; set; }

        [Required]
        public string? Address { get; set; }

    }
}
