using Microsoft.AspNetCore.Mvc;
using piano_store.Models.Interfaces;

namespace piano_store.Controllers
{
	public class HomeController : Controller
	{
		private IProductRepository productRepository;

		// Inject dependencies
		public HomeController(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		// Return view
		public IActionResult Index()
		{
			// Get trending products
			return View(productRepository.GetTrendingProducts());
		}
	}
}
