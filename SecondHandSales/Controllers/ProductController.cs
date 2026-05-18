using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandSales.Models;
using SecondHandSales.Repositories;
using SecondHandSales.ViewModels;

namespace SecondHandSales.Controllers
{
	[Authorize]
	public class ProductController : Controller
	{
		private readonly IGenericRepository<Product> _productRepo;
		private readonly IGenericRepository<Category> _categoryRepo;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public ProductController(
			IGenericRepository<Product> productRepo,
			IGenericRepository<Category> categoryRepo,
			IWebHostEnvironment webHostEnvironment)
		{
			_productRepo = productRepo;
			_categoryRepo = categoryRepo;
			_webHostEnvironment = webHostEnvironment;
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			var products = _productRepo.GetAll();
			return View(products);
		}

		public IActionResult Create()
		{
			var viewModel = new ProductCreateViewModel
			{
				CategoryList = _categoryRepo.GetAll().Select(c => new SelectListItem
				{
					Text = c.Name,
					Value = c.Id.ToString()
				})
			};
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductCreateViewModel model)
		{
			if (ModelState.IsValid)
			{
				string uniqueFileName = string.Empty;

				if (model.ImageFile != null)
				{
					string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

					if (!Directory.Exists(uploadsFolder))
					{
						Directory.CreateDirectory(uploadsFolder);
					}

					uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
					string filePath = Path.Combine(uploadsFolder, uniqueFileName);

					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						await model.ImageFile.CopyToAsync(fileStream);
					}
				}

				var product = new Product
				{
					Title = model.Title,
					Description = model.Description,
					Price = model.Price,
					CategoryId = model.CategoryId,
					ImageUrl = uniqueFileName,
					UserId = User.Identity?.Name
				};

				_productRepo.Add(product);
				_productRepo.Save();

				return RedirectToAction(nameof(Index));
			}

			model.CategoryList = _categoryRepo.GetAll().Select(c => new SelectListItem
			{
				Text = c.Name,
				Value = c.Id.ToString()
			});

			return View(model);
		}
	}
}