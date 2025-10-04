using Cortex.Mediator.Notifications;
using FullProject.Domain.Events;

namespace FullProject.Infrastructure.Kafka.Events
{
    /// <summary>
    /// Stellt einen Handler für das Ereignis <see cref="OrderCreated"/> dar.
    /// </summary>
    internal class OrderCreatedHandler : INotificationHandler<OrderCreated>
    {
        public Task Handle(OrderCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
