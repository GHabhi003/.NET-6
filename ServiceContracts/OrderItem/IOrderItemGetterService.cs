using WebAPIAssignment.DTO;

namespace WebAPIAssignment.ServiceContracts
{
    public interface IOrderItemGetterService
    {
        public Task<List<OrderItemResponse>> GetOrdersItemAsync();
        public Task<OrderItemResponse> GetOrderItemByIdAsync(Guid id);
    }
}
