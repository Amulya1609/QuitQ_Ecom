using Microsoft.AspNetCore.Mvc;
using QuitQ_Ecom.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using QuitQ_Ecom.DTOs;

namespace QuitQ_Ecom.Controllers
{
    [Route("api/order")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderRepo;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrder order, ILogger<OrderController> logger)
        {
            _orderRepo = order;
            _logger = logger;
        }

        [HttpGet("all/{userId:int}")]
        public async Task<IActionResult> GetOrdersOfUser(int userId)
        {
            try
            {
                var res = await _orderRepo.ViewAllOrdersByUserId(userId);
                if (res == null)
                {
                    _logger.LogInformation($"No orders found for user with ID {userId}");
                    return NoContent();
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching orders for user with ID {userId}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("store/{storedId:int}")]
        public async Task<IActionResult> Orders(int storedId)
        {
            try
            {
                var orders = await _orderRepo.ViewOrdersByStoreId(storedId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching orders for seller with ID {storedId}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{orderId:int}")]
        public async Task<IActionResult> GetOrderByOrderId(int orderId)
        {
            try
            {
                var order =await _orderRepo.ViewOrderByOrderId(orderId);
                if (order != null)
                {
                    return Ok(order);
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching orders  ID {orderId}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
