using Cortex.Mediator;
using FullProject.Domain.Commands;
using FullProject.Domain.Models.Orders;
using FullProject.Domain.Queries;
using FullProject.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullProject.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/order")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IApiProxyService _test;

        public OrderController(IMediator mediator, IApiProxyService test)
        {
            _mediator = mediator;
            _test = test;
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IList<OrderDto>> GetOrdersAsync()
        {
            var result = await _mediator.SendQueryAsync<GetOrders, IList<OrderDto>>(new GetOrders());

            await _mediator.SendCommandAsync<CreateOrderCommand, OrderDto>(new CreateOrderCommand(new OrderDto()));

            var test1 = await _test.Test();

            return result;
        }
    }
}
