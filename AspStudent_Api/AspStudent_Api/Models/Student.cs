using System.ComponentModel.DataAnnotations;

namespace AspStudent_Api.Models
{
    public class Student
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public string? StudentName { get; set; }

        [Required]
        public string? StudentClass { get; set; }

        [Required]
        public string? StudentSection { get; set; }
    }
}
