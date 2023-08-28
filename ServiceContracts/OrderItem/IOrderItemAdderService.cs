using WebAPIAssignment.DTO;

namespace WebAPIAssignment.ServiceContracts
{
    public interface IOrderItemAdderService
    {
        public Task<OrderItemResponse> AddOrderAsync(OrderItemRequest order);
    }
}
