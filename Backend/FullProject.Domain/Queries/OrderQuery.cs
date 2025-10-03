using Cortex.Mediator.Queries;
using FullProject.Domain.Entities;

namespace FullProject.Domain.Queries
{
    /// <summary>
    /// Represents a query to retrieve a list of orders.
    /// </summary>
    /// <remarks>This query is used to request a collection of <see cref="Order"/> objects.  The result of
    /// executing this query is an <see cref="IList{T}"/> containing the orders.</remarks>
    public record GetOrders() : IQuery<IList<Order>>;
}
