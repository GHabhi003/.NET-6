using WebAPIAssignment.DTO;
using WebAPIAssignment.ServiceContracts;
using WebAPIAssignment.Entities;
using WebAPIAssignment.RepositoryContracts;

namespace WebAPIAssignment.Services.OrderService
{
    public class AddOrderService : IOrderAdderService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        public AddOrderService(IOrdersRepository ordersRepository, IOrderItemsRepository orderItemsRepository)
        {
            _ordersRepository = ordersRepository;
            _orderItemsRepository = orderItemsRepository;
        }
        public async Task<OrderResponse> AddOrderAsync(OrderRequest orderRequest)
        {
            if (orderRequest != null)
            {
                //Convert from DTO to Entitytype
                var order = orderRequest.ToOrder();

                //Add Order
                var addOrderResponse = await _ordersRepository.AddOrder(order);
                
                //Convert back to DTO response object
                var response = addOrderResponse.ToOrderResponse();
                if (response != null)
                {
                    foreach (var item in orderRequest.OrderItemsRequest)
                    {
                        var orderItem = item.ToOrderItem();
                        
                        //Attach ID
                        orderItem.OrderId = response.OrderId;
                        
                        //Add orderItem to DB
                        var addOrderItemResponse = await _orderItemsRepository.AddOrderItem(orderItem);
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
