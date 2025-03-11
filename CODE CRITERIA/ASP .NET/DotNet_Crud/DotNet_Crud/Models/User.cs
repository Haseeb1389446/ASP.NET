using System.ComponentModel.DataAnnotations;

namespace dotnet_crud.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Age { get; set; }

        public string? City { get; set; }
    }
}
