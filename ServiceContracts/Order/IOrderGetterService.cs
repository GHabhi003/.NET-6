using WebAPIAssignment.DTO;

namespace WebAPIAssignment.ServiceContracts
{
    public interface IOrderGetterService
    {
        public Task<List<OrderResponse>> GetOrdersAsync();
        public Task<OrderResponse> GetOrderByIdAsync(Guid id);
    }
}
