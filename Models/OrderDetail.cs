namespace piano_store.Models
{
    public class OrderDetail
    {
        // OrderDetail properties
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
