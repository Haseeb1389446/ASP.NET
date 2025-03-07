using System.ComponentModel.DataAnnotations;

namespace Sending_Data_in_Database.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        public string? name { get; set; }

        public string? description { get; set; }

        public string? price { get; set; }

    }
}
