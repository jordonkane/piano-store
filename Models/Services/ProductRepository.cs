using piano_store.Models.Interfaces;

namespace piano_store.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductDetail(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetTrendingProducts()
        {
            throw new NotImplementedException();
        }
    }
}
