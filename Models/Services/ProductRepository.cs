using piano_store.Data;
using piano_store.Models.Interfaces;

namespace piano_store.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private PianoStoreDbContext dbContext;

        // Inject the PianoStoreDbContext
        public ProductRepository(PianoStoreDbContext dbContext)
        {
            // Can access everything within the PianoStoreDbContext
            this.dbContext = dbContext;
        }

        // Returns a list of all products
        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products;
        }

        // Returns details of products
        public Product? GetProductDetail(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        // Returns all trending products
        public IEnumerable<Product> GetTrendingProducts()
        {
            return dbContext.Products.Where(p => p.IsTrendingProduct);
        }
    }
}
