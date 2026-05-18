using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondHandSales.ViewModels
{
	public class ProductCreateViewModel
	{
		[Required(ErrorMessage = "Ürün başlığı zorunludur.")]
		[StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = "Ürün açıklaması zorunludur.")]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = "Fiyat alanı zorunludur.")]
		[Range(0.1, 1000000, ErrorMessage = "Geçerli bir fiyat giriniz.")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Lütfen bir ürün resmi yükleyiniz.")]
		public IFormFile ImageFile { get; set; }

		[Required(ErrorMessage = "Lütfen bir kategori seçiniz.")]
		public int CategoryId { get; set; }

		public IEnumerable<SelectListItem>? CategoryList { get; set; }
	}
}