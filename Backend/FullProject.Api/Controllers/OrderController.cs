using Cortex.Mediator;
using FullProject.Application.Orders.Queries;
using FullProject.Domain.Entities;
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

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IList<Order>> GetOrdersAsync()
        {
            var result = await _mediator.SendQueryAsync<GetOrders, IList<Order>>(new GetOrders());

            return result;
        }
    }
}
