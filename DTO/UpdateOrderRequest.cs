using WebAPIAssignment.Entities;

namespace WebAPIAssignment.DTO
{
    public class UpdateOrderRequest
    {
        public Guid OrderId { get; set; }
        public string OrderNumber { get; set; }

        public string CustomerName { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalAmount { get; set; }

        public List<UpdateOrderItemRequest> OrderItemsRequest { get; set; } = new List<UpdateOrderItemRequest>();

        public Order ToOrder()
        {
            return new Order
            {
                OrderId = OrderId,
                OrderNumber = OrderNumber,
                CustomerName = CustomerName,
                OrderDate = OrderDate,
                TotalAmount = TotalAmount
            };
        }
    }
}
