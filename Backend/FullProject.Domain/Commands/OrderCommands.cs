using Cortex.Mediator.Commands;
using FullProject.Domain.Entities;

namespace FullProject.Domain.Commands
{
    /// <summary>
    /// Befehl zum Erstellen einer neuen Bestellung.
    /// </summary>
    /// <remarks>
    /// Dieser Befehl enthält die zu erstellende Bestellung und wird verwendet, um eine neue Bestellung im System anzulegen.
    /// </remarks>
    /// <param name="order">Die zu erstellende Bestellung. Dieser Parameter darf nicht <see langword="null"/> sein.</param>
    public record CreateOrderCommand(Order order) : ICommand<Order>;
}