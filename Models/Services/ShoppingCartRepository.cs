using Microsoft.EntityFrameworkCore;
using piano_store.Data;
using piano_store.Models.Interfaces;
using System.Diagnostics;

namespace piano_store.Models.Services
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {

        // Communicate with dbset property
        private PianoStoreDbContext dbContext;
        
        public ShoppingCartRepository(PianoStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Implemented methods from IShoppingCartRepository
        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }
        public string? ShoppingCartId { get; set; } 

        // Store card id in session. Executed automatically when an instance of this class is created.
        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            // Access the session
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            
            // Access dbcontext
            PianoStoreDbContext context = services.GetService<PianoStoreDbContext>() ?? throw new Exception("Error Initializing ");

            // Cart id for incoming user (Check if user has one or create new one)
            String cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            // Store value of the cart id in session
            session?.SetString("CartId", cartId);

            // Retrieve shopping cart id from session
            return new ShoppingCartRepository(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product)
        {
            // Add product to shopping cart (if not already in cart)
            var shoppingCartItem = dbContext.ShoppingCartItems.FirstOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);
            
            // Check if item not in shopping cart
            if (shoppingCartItem == null)
            {
                // Create a new item
                shoppingCartItem = new ShoppingCartItem
                {
                    // Assign properties
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Qty = 1 // Default value when item is added in cart
                };

                dbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else // Otherwise, increase the quantity of item
            {
                shoppingCartItem.Qty++;
            }
            dbContext.SaveChanges();
        }

        public void ClearCart()
        {
            // Remove all items from cart
            var cartItems = dbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId);
            dbContext.ShoppingCartItems.RemoveRange(cartItems);
            dbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            // Return items in shopping cart (if not null)
            return ShoppingCartItems ??= dbContext.ShoppingCartItems.Where(s=>s.ShoppingCartId == ShoppingCartId)
                .Include(p=>p.Product).ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            // Get the total number of items in cart
            var totalCost = dbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId)
                .Select(s => s.Product.Price * s.Qty).Sum();
            return totalCost;
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = dbContext.ShoppingCartItems.FirstOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);
            var quantity = 0;
            
            // Check if cart is not empty before proceeding
            if(shoppingCartItem != null)
            {
                // Check if item quantity is greater than 1
                if(shoppingCartItem.Qty > 1)
                {
                    // Decrease quantity
                    shoppingCartItem.Qty--;
                    quantity = shoppingCartItem.Qty;
                }
                else // If quantity is greater than 1
                {
                    // Remove item from shopping cart
                    dbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            dbContext.SaveChanges();
            return quantity;
        }
    }
}
