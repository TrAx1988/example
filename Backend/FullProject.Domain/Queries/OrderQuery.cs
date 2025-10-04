using Cortex.Mediator.Queries;
using FullProject.Domain.Entities;

namespace FullProject.Domain.Queries
{
    /// <summary>
    /// Stellt eine Abfrage dar, um eine Liste von Bestellungen abzurufen.
    /// </summary>
    /// <remarks>
    /// Diese Abfrage wird verwendet, um eine Sammlung von <see cref="Order"/>-Objekten anzufordern.
    /// Das Ergebnis der Ausführung dieser Abfrage ist eine <see cref="IList{T}"/>, die die Bestellungen enthält.
    /// </remarks>
    public record GetOrders() : IQuery<IList<Order>>;
}
