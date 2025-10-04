using Cortex.Mediator.Notifications;
using FullProject.Domain.Events;

namespace FullProject.Infrastructure.Kafka.Events
{
    public class OrderCreatedHandler : INotificationHandler<OrderCreated>
    {
        public Task Handle(OrderCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
