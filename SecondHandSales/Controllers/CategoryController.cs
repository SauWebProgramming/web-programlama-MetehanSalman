using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecondHandSales.Models;
using SecondHandSales.Repositories;

namespace SecondHandSales.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CategoryController : Controller
	{
		private readonly IGenericRepository<Category> _categoryRepo;

		public CategoryController(IGenericRepository<Category> categoryRepo)
		{
			_categoryRepo = categoryRepo;
		}

		public IActionResult Index()
		{
			return View(_categoryRepo.GetAll());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Category category)
		{
			if (ModelState.IsValid)
			{
				_categoryRepo.Add(category);
				_categoryRepo.Save();
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}
	}
}