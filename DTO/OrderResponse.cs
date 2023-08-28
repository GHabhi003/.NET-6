using WebAPIAssignment.Entities;

namespace WebAPIAssignment.DTO
{
    public class OrderResponse
    {
        public Guid OrderId { get; set; }
        public string OrderNumber { get; set; } 
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public List<OrderItemResponse> OrderItemsResponse { get; set; } = new List<OrderItemResponse>();
        public override bool Equals(object? obj)
        {
            var orderResponse = obj as OrderResponse;
            return (this.OrderId == orderResponse.OrderId) && (this.OrderNumber == orderResponse.OrderNumber) && (this.OrderDate == orderResponse.OrderDate) && (this.TotalAmount == orderResponse.TotalAmount) && (this.CustomerName == orderResponse.CustomerName);
        }
    }

    public static class OrderResponseExtensions
    {
        public static OrderResponse ToOrderResponse(this Order order)
        {
            return new OrderResponse()
            {
                OrderId = order.OrderId,
                OrderNumber = order.OrderNumber,
                CustomerName = order.CustomerName,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
            };
        }
    }
}
