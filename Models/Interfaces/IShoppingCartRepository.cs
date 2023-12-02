namespace piano_store.Models.Interfaces
{
    public interface IShoppingCartRepository
    {
        // Shopping cart methods
        void AddToCart(Product product);
        int RemoveFromCart(Product product);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }
    }
}
