using System.ComponentModel.DataAnnotations;

namespace DotNet_Crud.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Desc { get; set; }

        public string? Price { get; set; }
    }
}
