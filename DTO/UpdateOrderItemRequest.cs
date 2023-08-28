using WebAPIAssignment.Entities;

namespace WebAPIAssignment.DTO
{
    public class UpdateOrderItemRequest
    {
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderItem ToOrderItem()
        {
            return new OrderItem
            {
                OrderItemId = OrderItemId,
                OrderId = OrderId,
                ProductName = ProductName,
                Quantity = Quantity,
                UnitPrice = UnitPrice,
                TotalPrice = TotalPrice,
            };
        }
    }
}
