using Cortex.Mediator;
using Cortex.Mediator.Commands;
using FullProject.Domain.Commands;
using FullProject.Domain.Events;
using FullProject.Domain.Models.Orders;
using FullProject.Infrastructure;

namespace FullProject.Application.Commerce.Orders.Commands
{
    /// <summary>
    /// Stellt einen Handler für das Ereignis <see cref="CreateOrderCommand"/> dar.
    /// </summary>
    public class CreateUserHandler : ICommandHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IMediator _mediator;
        private readonly ITimeService _timeService;

        public CreateUserHandler(IMediator mediator, ITimeService timeService)
        {
            _mediator = mediator;
            _timeService = timeService;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var currentTime = await _timeService.GetCurrentDateTimeAsync();

            await _mediator.PublishAsync(new OrderCreated(command.order, currentTime), cancellationToken);

            return await Task.FromResult(command.order);
        }
    }
}
