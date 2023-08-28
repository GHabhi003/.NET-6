using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIAssignment.DTO;
using WebAPIAssignment.Entities;
using WebAPIAssignment.ServiceContracts;

namespace WebAPIAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderAdderService _orderAdderService;
        private readonly IOrderDeleterService _orderDeleterService;
        private readonly IOrderUpdateService _orderUpdateService;
        private readonly IOrderGetterService _orderGetterService;
        public OrderController(ILogger<OrderController> logger, IOrderAdderService orderAdderService, IOrderDeleterService orderDeleterService, IOrderGetterService orderGetterService, IOrderUpdateService orderUpdateService)
        {
            _logger = logger;
            _orderAdderService = orderAdderService;
            _orderDeleterService = orderDeleterService;
            _orderGetterService = orderGetterService;
            _orderUpdateService = orderUpdateService;
        }
        /// <summary>
        /// Get API to fetch all the orders
        /// </summary>
        /// <returns>Return complete orders list</returns>
        [HttpGet("GetOrders")]
        public async Task<ActionResult<List<OrderResponse>>> GetOrders()
        {
            return await _orderGetterService.GetOrdersAsync();
        }

        [HttpGet("GetOrder/{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrderById(Guid id)
        {
            return await _orderGetterService.GetOrderByIdAsync(id);
        }

        [HttpPost("AddOrder")]
        public async Task<ActionResult<OrderResponse>> AddOrder([FromBody] OrderRequest orderRequest)
        {
            var response = await _orderAdderService.AddOrderAsync(orderRequest);
            return CreatedAtAction(nameof(GetOrderById), new { id = response.OrderId }, response);   
        }

        [HttpPut("UpdateOrder")]
        public async Task<ActionResult<OrderResponse>> UpdateOrder([FromBody] UpdateOrderRequest orderRequest)
        {
            return await _orderUpdateService.UpdateOrderAsync(orderRequest);
        }

        [HttpDelete("DeleteOrder/{id}")]
        public async Task<ActionResult<bool>> DeleteOrder(Guid id)
        {
            return await _orderDeleterService.DeleteOrderAsync(id);
        }
    }
}
