using Microsoft.AspNetCore.Mvc;
using piano_store.Models.Interfaces;

namespace piano_store.Controllers
{
    public class ShoppingCartController : Controller
    {

        private IShoppingCartRepository shoppingCartRepository;
        private IProductRepository productRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var items = shoppingCartRepository.GetShoppingCartItems();
            shoppingCartRepository.ShoppingCartItems = items;
            ViewBag.CartTotal = shoppingCartRepository.GetShoppingCartTotal(); // Transfer data from controller to view with a ViewBag
            return View(items);
        }

        public RedirectToActionResult AddToShoppingCart(int pId)
        {
            var product = productRepository.GetAllProducts().FirstOrDefault(p => p.Id == pId);

            // Add to cart
            if (product != null)
            {
                shoppingCartRepository.AddToCart(product);
                int cartCount = shoppingCartRepository.GetShoppingCartItems().Count;
                HttpContext.Session.SetInt32("CartCount", cartCount);
            }

            // Redirect to index page of shopping cart after adding to cart
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int pId)
        {
            var product = productRepository.GetAllProducts().FirstOrDefault(p => p.Id == pId);

            // Remove from cart
            if (product != null)
            {
                shoppingCartRepository.RemoveFromCart(product);
                int cartCount = shoppingCartRepository.GetShoppingCartItems().Count;
                HttpContext.Session.SetInt32("CartCount", cartCount);
            }

            // Redirect to index page of shopping cart after removing from cart
            return RedirectToAction("Index");
        }
    }
}
