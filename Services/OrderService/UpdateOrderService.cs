using WebAPIAssignment.DTO;
using WebAPIAssignment.RepositoryContracts;
using WebAPIAssignment.ServiceContracts;

namespace WebAPIAssignment.Services.OrderService
{
    public class UpdateOrderService : IOrderUpdateService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        public UpdateOrderService(IOrdersRepository ordersRepository, IOrderItemsRepository orderItemsRepository)
        {
            _ordersRepository = ordersRepository;
            _orderItemsRepository = orderItemsRepository;
        }
        public async Task<OrderResponse> UpdateOrderAsync(UpdateOrderRequest orderRequest)
        {
            if (orderRequest != null)
            {
                //Convert from DTO to Entitytype
                var order = orderRequest.ToOrder();

                //Add Order
                var addOrderResponse = await _ordersRepository.UpdateOrder(order);

                //Convert back to DTO response object
                var response = addOrderResponse.ToOrderResponse();
                if (response != null)
                {
                    foreach (var item in orderRequest.OrderItemsRequest)
                    {
                        var orderItem = item.ToOrderItem();

                        //Add orderItem to DB
                        var addOrderItemResponse = await _orderItemsRepository.UpdateOrderItem(orderItem);
                        response.OrderItemsResponse.Add(addOrderItemResponse.ToOrderItemResponse());
                    }
                }
                else
                {
                    throw new Exception("Unable to add order in database");
                }
                return response;
            }
            else
            {
                throw new ArgumentNullException("Request order is null.");
            }
        }
    }
}
