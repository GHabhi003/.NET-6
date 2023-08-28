using WebAPIAssignment.DTO;

namespace WebAPIAssignment.ServiceContracts
{
    public interface IOrderAdderService
    {
        public Task<OrderResponse> AddOrderAsync(OrderRequest order);
    }
}
