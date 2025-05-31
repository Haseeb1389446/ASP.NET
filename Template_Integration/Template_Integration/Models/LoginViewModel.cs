using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;

namespace Template_Integration.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(8,ErrorMessage = "The Password Field Must Contain The Eight Characters")]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
