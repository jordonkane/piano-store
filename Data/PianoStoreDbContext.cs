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
	}
}
