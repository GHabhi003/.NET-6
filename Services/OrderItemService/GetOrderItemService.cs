using WebAPIAssignment.DTO;
using WebAPIAssignment.ServiceContracts;

namespace WebAPIAssignment.Services.OrderItem
{
    public class GetOrderItemService : IOrderItemGetterService
    {
        public Task<OrderItemResponse> GetOrderItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderItemResponse>> GetOrdersItemAsync()
        {
            throw new NotImplementedException();
        }
    }
}
