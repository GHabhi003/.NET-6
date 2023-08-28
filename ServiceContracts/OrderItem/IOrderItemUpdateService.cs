using WebAPIAssignment.DTO;

namespace WebAPIAssignment.ServiceContracts
{
    public interface IOrderItemUpdateService
    {
        public Task<OrderItemResponse> UpdateOrderItemAsync(OrderItemRequest orderItemRequest);
    }
}
