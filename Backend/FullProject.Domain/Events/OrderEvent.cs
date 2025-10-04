using Cortex.Mediator.Notifications;
using FullProject.Domain.Entities;

namespace FullProject.Domain.Events
{
    /// <summary>
    /// Represents a notification that an order has been created.
    /// </summary>
    /// <remarks>This notification contains the details of the created order and the date when the order was
    /// created. It is typically used in event-driven systems to signal that a new order has been successfully
    /// created.</remarks>
    /// <param name="order">The order that was created. This parameter cannot be <see langword="null"/>.</param>
    /// <param name="date">The date and time when the order was created.</param>
    public record OrderCreated(Order order, DateTime date) : INotification;
}
