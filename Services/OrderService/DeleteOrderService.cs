using WebAPIAssignment.RepositoryContracts;
using WebAPIAssignment.ServiceContracts;

namespace WebAPIAssignment.Services.OrderService
{
    public class DeleteOrderService : IOrderDeleterService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        public DeleteOrderService(IOrdersRepository ordersRepository, IOrderItemsRepository orderItemsRepository)
        {
            _ordersRepository = ordersRepository;
            _orderItemsRepository = orderItemsRepository;
        }
        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            var orderResponse = await _ordersRepository.DeleteOrderByOrderId(id);
            if (orderResponse == true)
            {
                return true;
                //bool result = true;
                //var listOfOrderItems = await _orderItemsRepository.GetOrderItemsByOrderId(id);
                //if (listOfOrderItems.Count > 0)
                //{
                //    foreach (var item in listOfOrderItems)
                //    {
                //        var output = await _orderItemsRepository.DeleteOrderItemByOrderItemId(item.OrderItemId);
                //        if (output == false)
                //        {
                //            return false;
                //        }
                //    }
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            else
            {
                throw new Exception("No such Id exists.");
            }        
        }
    }
}
