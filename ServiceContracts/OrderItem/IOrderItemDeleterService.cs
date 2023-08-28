namespace WebAPIAssignment.ServiceContracts
{
    public interface IOrderItemDeleterService
    {
        public Task<bool> DeleteOrderItemAsync(Guid id);
    }
}
