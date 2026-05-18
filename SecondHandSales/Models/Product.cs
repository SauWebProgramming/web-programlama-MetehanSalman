using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandSales.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Ürün başlığı zorunludur.")]
		[StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = "Ürün açıklaması zorunludur.")]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = "Fiyat alanı zorunludur.")]
		[Range(0.1, 1000000, ErrorMessage = "Geçerli bir fiyat giriniz.")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		public string? ImageUrl { get; set; }

		[Required]
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public Category? Category { get; set; }

		public string? UserId { get; set; }
	}
}