using Cortex.Mediator;
using Cortex.Mediator.Commands;
using FullProject.Domain.Commands;
using FullProject.Domain.Entities;
using FullProject.Domain.Events;
using FullProject.Infrastructure;

namespace FullProject.Application.Orders.Commands
{
    /// <summary>
    /// Stellt einen Handler für das Ereignis <see cref="CreateOrderCommand"/> dar.
    /// </summary>
    public class CreateUserHandler : ICommandHandler<CreateOrderCommand, Order>
    {
        private readonly IMediator _mediator;
        private readonly ITimeService _timeService;

        public CreateUserHandler(IMediator mediator, ITimeService timeService)
        {
            _mediator = mediator;
            _timeService = timeService;
        }

        public async Task<Order> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var currentTime = await _timeService.GetCurrentDateTimeAsync();

            await _mediator.PublishAsync(new OrderCreated(command.order, currentTime), cancellationToken);

            return await Task.FromResult(command.order);
        }
    }
}
