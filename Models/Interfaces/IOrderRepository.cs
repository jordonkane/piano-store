namespace piano_store.Models.Interfaces
{
    public interface IOrderRepository
    {
        // Place an order
        void PlaceOrder(Order order);
    }
}
