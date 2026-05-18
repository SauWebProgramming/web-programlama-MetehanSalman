using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondHandSales.Models;

namespace SecondHandSales.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Elektronik" },
				new Category { Id = 2, Name = "Moda / Giyim" },
				new Category { Id = 3, Name = "Ev / Yaşam" },
				new Category { Id = 4, Name = "Kitap / Hobi" }
			);
		}
	}
}