using piano_store.Models.Interfaces;

namespace piano_store.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> ProductsList = new List<Product>()
        {
            new Product{Id = 1, Name = "Piano 1", Price = 25, Detail = "Description", ImageUrl=""},
            new Product{Id = 2, Name = "Piano 2", Price = 30, Detail = "Description", ImageUrl=""},
            new Product{Id = 3, Name = "Piano 3", Price = 40, Detail = "Description", ImageUrl=""},
        };

        // Returns a list of all products
        public IEnumerable<Product> GetAllProducts()
        {
            return ProductsList;
        }

        // Returns details of products
        public Product GetProductDetail(int id)
        {
            return ProductsList.FirstOrDefault(p => p.Id == id);
        }

        // Returns all trending products
        public IEnumerable<Product> GetTrendingProducts()
        {
            return ProductsList.Where(p => p.IsTrendingProduct);
        }
    }
}
