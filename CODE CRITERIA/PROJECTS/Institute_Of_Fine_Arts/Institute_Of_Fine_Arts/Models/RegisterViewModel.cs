using System.ComponentModel.DataAnnotations;

namespace Institute_Of_Fine_Arts.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? UserEmail { get; set; }

        [Required]
        public string? UserPassword { get; set; }
    }
}
