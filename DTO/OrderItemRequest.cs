using WebAPIAssignment.Entities;

namespace WebAPIAssignment.DTO
{
    public class OrderItemRequest
    {
        public Guid OrderId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderItem ToOrderItem()
        {
            return new OrderItem
            {
                OrderItemId = Guid.NewGuid(),
                ProductName = ProductName,
                Quantity = Quantity,
                UnitPrice = UnitPrice,
                TotalPrice = TotalPrice,
            };
        }
    }
}
