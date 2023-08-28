namespace WebAPIAssignment.ServiceContracts
{
    public interface IOrderDeleterService
    {
        public Task<bool> DeleteOrderAsync(Guid id);
    }
}
