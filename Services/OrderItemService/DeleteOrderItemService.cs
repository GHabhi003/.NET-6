using WebAPIAssignment.ServiceContracts;

namespace WebAPIAssignment.Services.OrderItem
{
    public class DeleteOrderItemService : IOrderItemDeleterService
    {
        public Task<bool> DeleteOrderItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
