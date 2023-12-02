namespace piano_store.Models
{
    public class ShoppingCartItem
    {
        // Unique id for each item in cart
        public int Id { get; set; }

        // Product that user wants to add in cart
        public Product? Product { get; set; }

        // Quantity of product that user wants
        public int Qty { get; set; }

        // Unique shopping cart id
        public string? ShoppingCartId { get; set; }

    }
}
