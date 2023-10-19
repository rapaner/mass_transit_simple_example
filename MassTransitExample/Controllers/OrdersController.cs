using MassTransit;
using MassTransitExample.Models;
using Microsoft.AspNetCore.Mvc;
using SharedModels;

namespace MassTransitExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IRequestClient<GetOrder> _orderRequestClient;

        public OrdersController(IPublishEndpoint publishEndpoint,
                                ISendEndpointProvider sendEndpointProvider,
                                IRequestClient<GetOrder> orderRequestClient)
        {
            _publishEndpoint = publishEndpoint;
            _sendEndpointProvider = sendEndpointProvider;
            _orderRequestClient = orderRequestClient;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            await _publishEndpoint.Publish<OrderCreated>(new
            {
                Id = 1,
                orderDto.ProductName,
                orderDto.Quantity,
                orderDto.Price
            });

            return Ok();
        }

        [HttpDelete("cancel")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("exchange:order-service"));
            await endpoint.Send<CancelOrder>(new
            {
                OrderId = orderId
            });

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResult>> GetOrder([FromRoute] int id, CancellationToken token)
        {
            var response = await _orderRequestClient.GetResponse<OrderResult>(new { OrderId = id }, token);

            return Ok(response);
        }
    }
}