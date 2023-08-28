using WebAPIAssignment.Entities;

namespace WebAPIAssignment.DTO
{
    public class OrderRequest
    {
        public string OrderNumber { get; set; }

        public string CustomerName { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalAmount { get; set; }

        public List<OrderItemRequest> OrderItemsRequest { get; set; } = new List<OrderItemRequest>();

        public Order ToOrder()
        {
            return new Order { 
                OrderId = Guid.NewGuid(), 
                OrderNumber = OrderNumber,
                CustomerName = CustomerName,
                OrderDate = DateTime.Now.Date,
                TotalAmount = TotalAmount
            };
        }
    }
}
