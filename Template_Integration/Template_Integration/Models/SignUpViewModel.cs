using System.ComponentModel.DataAnnotations;

namespace Template_Integration.Models
{
    public class SignUpViewModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        public string? UserEmail { get; set; }

        [Required]
        [MinLength(8,ErrorMessage = "The Password Field Must Contain The Eight Characters")]
        public string? UserPassword { get; set; }
    }
}
