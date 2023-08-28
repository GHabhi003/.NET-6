using WebAPIAssignment.DTO;
using WebAPIAssignment.RepositoryContracts;
using WebAPIAssignment.ServiceContracts;

namespace WebAPIAssignment.Services.OrderService
{
    public class GetOrderService : IOrderGetterService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        public GetOrderService(IOrdersRepository ordersRepository, IOrderItemsRepository orderItemsRepository)
        {
            _ordersRepository = ordersRepository;
            _orderItemsRepository = orderItemsRepository;
        }
        public async Task<OrderResponse> GetOrderByIdAsync(Guid id)
        {
            //Get all orders
            var order = await _ordersRepository.GetOrderByOrderId(id);
            //Get all order items
            var orderItems = await _orderItemsRepository.GetOrderItemsByOrderId(id);

            if (order!=null)
            {
                var orderResponse = order.ToOrderResponse();
                orderResponse.OrderItemsResponse = orderItems.Select(x => x.ToOrderItemResponse()).ToList();
                return orderResponse;
            }
            else
            {
                throw new Exception("Not such order exists with gicen orderId.");
            }
            
        }

        public async Task<List<OrderResponse>> GetOrdersAsync()
        {
            List<OrderResponse> orderResponseList = new List<OrderResponse>();
            //Get all orders
            var listOfOrders = await _ordersRepository.GetAllOrders();
            //Get all order items
            var listOfOrderItems = await _orderItemsRepository.GetAllOrderItems();

            foreach (var order in listOfOrders)
            {
                var orderItems = listOfOrderItems.Where(x => x.OrderId == order.OrderId).Select(x => x.ToOrderItemResponse()).ToList();
                var orderResponse = order.ToOrderResponse();
                orderResponse.OrderItemsResponse = orderItems;
                orderResponseList.Add(orderResponse);
            }
            return orderResponseList;
        }
    }
}
