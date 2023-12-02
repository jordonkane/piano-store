using piano_store.Data;
using piano_store.Models.Interfaces;

namespace piano_store.Models.Services
{
    public class OrderRepository : IOrderRepository
    {
        // Store order information in db
        private PianoStoreDbContext dbContext;
        private IShoppingCartRepository shoppingCartRepository;

        public OrderRepository(PianoStoreDbContext dbContext, IShoppingCartRepository shoppingCartRepository)
        {
            this.dbContext = dbContext;
            this.shoppingCartRepository = shoppingCartRepository;
        }
        public void PlaceOrder(Order order)
        {
            // Store data in orderdetails table
            var shoppingCartItems = shoppingCartRepository.GetShoppingCartItems();
            order.OrderDetails = new List<OrderDetail>();
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    // Orderdetail properties
                    Quantity = item.Qty,
                    ProductId = item.Product.Id,
                    Price = item.Product.Price
                };
                order.OrderDetails.Add(orderDetail);
            }
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = shoppingCartRepository.GetShoppingCartTotal();
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

        }
    }
}
