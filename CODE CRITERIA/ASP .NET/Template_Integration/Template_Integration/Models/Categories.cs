using System.ComponentModel.DataAnnotations;

namespace Template_Integration.Models
{
	public class Categories
	{
		[Key]
        public int CategoryId { get; set; }

		public string? CategoryName { get; set; }

	}
}
