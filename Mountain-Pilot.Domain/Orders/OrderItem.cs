using Mountain_Pilot.Domain.Catalog;

namespace Mountain_Pilot.Domain.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }

        public Item Item { get; set; }

        public decimal Price => Item.Price * Quantity;

        public int Quantity { get; set; }
    }
}