using piano_store.Models;
using Microsoft.EntityFrameworkCore;

namespace piano_store.Data
{
	// Serves as a gateway to the database
	public class PianoStoreDbContext : DbContext
	{
		public PianoStoreDbContext(DbContextOptions<PianoStoreDbContext>options) : base(options) // pass 'options' variable to base dbcontext class
		{
		}

		// Properties (will be mapped database table name at runtime)
		public DbSet<Product> Products { get; set; }
		public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Get a new instance of the Product class and set its properties
			modelBuilder.Entity<Product>().HasData(

				new Product { Id = 1, Name = "Piano 1", Detail = "Some details", Price = 15, IsTrendingProduct = true, ImageUrl = "" },
				new Product { Id = 2, Name = "Piano 2", Detail = "Some details", Price = 15, IsTrendingProduct = true, ImageUrl = "" },
				new Product { Id = 3, Name = "Piano 3", Detail = "Some details", Price = 15, IsTrendingProduct = true, ImageUrl = "" },
				new Product { Id = 4, Name = "Piano 4", Detail = "Some details", Price = 15, IsTrendingProduct = false, ImageUrl = "" },
				new Product { Id = 5, Name = "Piano 5", Detail = "Some details", Price = 15, IsTrendingProduct = false, ImageUrl = "" },
				new Product { Id = 6, Name = "Piano 6", Detail = "Some details", Price = 15, IsTrendingProduct = false, ImageUrl = "" },
				new Product { Id = 7, Name = "Piano 7", Detail = "Some details", Price = 15, IsTrendingProduct = false, ImageUrl = "" }

				);
		}
	}
}
