using System.ComponentModel.DataAnnotations;

namespace SecondHandSales.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Kategori adı zorunludur.")]
		[StringLength(50, ErrorMessage = "Kategori adı en fazla 50 karakter olabilir.")]
		public string Name { get; set; } = string.Empty;

		public ICollection<Product> Products { get; set; } = new List<Product>();
	}
}