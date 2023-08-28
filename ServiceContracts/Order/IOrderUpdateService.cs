using WebAPIAssignment.DTO;

namespace WebAPIAssignment.ServiceContracts
{
    public interface IOrderUpdateService
    {
        public Task<OrderResponse> UpdateOrderAsync(UpdateOrderRequest orderRequest);
    }
}
