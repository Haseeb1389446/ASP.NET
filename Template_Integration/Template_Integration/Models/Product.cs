using System.ComponentModel.DataAnnotations;

namespace Template_Integration.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDesc { get; set; }

        public string ProductPrice { get; set; }

        public string ProductQty { get; set; }

        public int CategoryId { get; set; }

        public string ProductImage { get; set; }

        public Categories Category { get; set; }
    }
}
