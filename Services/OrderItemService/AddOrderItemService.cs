using WebAPIAssignment.DTO;
using WebAPIAssignment.ServiceContracts;

namespace WebAPIAssignment.Services
{
    public class AddOrderItemService : IOrderItemAdderService
    {
        public Task<OrderItemResponse> AddOrderAsync(OrderItemRequest order)
        {
            throw new NotImplementedException();
        }
    }
}
