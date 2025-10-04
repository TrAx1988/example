using Cortex.Mediator;
using FullProject.Domain.Entities;
using FullProject.Domain.Events;
using FullProject.Domain.Queries;
using FullProject.Infrastructure;
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
        private readonly ITimeService _timeService;

        public OrderController(IMediator mediator, ITimeService timeService)
        {
            _mediator = mediator;
            _timeService = timeService;
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IList<Order>> GetOrdersAsync()
        {
            var result = await _mediator.SendQueryAsync<GetOrders, IList<Order>>(new GetOrders());

            await _mediator.PublishAsync(new OrderCreated(new Order(), _timeService.GetCurrentDateTime()));

            return result;
        }
    }
}
