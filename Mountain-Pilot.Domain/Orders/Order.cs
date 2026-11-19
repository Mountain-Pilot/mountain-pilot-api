using System.ComponentModel.DataAnnotations;

namespace Mountain_Pilot.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreatedDate {get; set;}

        public decimal TotalPrice => Items.Sum(item => item.Price);

        public List<OrderItem> Items { get; set; } = new();
    }
}