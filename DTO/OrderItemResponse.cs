using WebAPIAssignment.Entities;

namespace WebAPIAssignment.DTO
{
    public class OrderItemResponse
    {
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
    public static  class OrderItemResponseExtension
    {
        public static OrderItemResponse ToOrderItemResponse(this OrderItem orderItem)
        {
            return new OrderItemResponse()
            {
                OrderId = orderItem.OrderId,
                OrderItemId = orderItem.OrderItemId,
                ProductName = orderItem.ProductName,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
                TotalPrice = orderItem.TotalPrice
            };
        }
    }
}
