using FakeItEasy;
using piano_store.Models.Interfaces;
using Xunit;

namespace piano_store.Tests.Controller
{
    public class HomeControllerTests
    {
        private IProductRepository productRepository;
        public HomeControllerTests()
        {
            // Dependencies
            productRepository = A.Fake<IProductRepository>();
        }

        [Fact]
        public void CanGetTrendingProducts()
        {
            var result = productRepository.GetTrendingProducts();
            Assert.NotNull(result);
        }
    }
}
