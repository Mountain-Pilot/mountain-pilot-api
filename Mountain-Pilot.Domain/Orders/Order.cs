using System.ComponentModel.DataAnnotations;

namespace Mountain_Pilot.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }

        public List<OrderItem> Items { get; set; } = new();
    }
}