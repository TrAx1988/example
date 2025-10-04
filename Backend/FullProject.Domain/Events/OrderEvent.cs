using Cortex.Mediator.Notifications;
using FullProject.Domain.Models.Orders;

namespace FullProject.Domain.Events
{
    /// <summary>
    /// Stellt eine Benachrichtigung dar, dass eine Bestellung erstellt wurde.
    /// </summary>
    /// <remarks>
    /// Diese Benachrichtigung enthält die Details der erstellten Bestellung sowie das Datum, an dem die Bestellung
    /// angelegt wurde. Sie wird typischerweise in ereignisgesteuerten Systemen verwendet, um anzuzeigen, dass eine neue Bestellung
    /// erfolgreich erstellt wurde.
    /// </remarks>
    /// <param name="order">Die erstellte Bestellung. Dieser Parameter darf nicht <see langword="null"/> sein.</param>
    /// <param name="date">Das Datum und die Uhrzeit, zu der die Bestellung erstellt wurde.</param>
    public record OrderCreated(OrderDto order, DateTime date) : INotification;
}