using Microsoft.AspNetCore.Mvc;
using piano_store.Models.Interfaces;

namespace piano_store.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepository;

        // Dependency injection
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // Action methods

        // Return a view
        public IActionResult Shop()
        {
            // Retrieve necessary data to be displayed in the view
            return View(productRepository.GetAllProducts());
        }
    }
}
