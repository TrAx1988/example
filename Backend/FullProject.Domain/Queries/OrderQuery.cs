using Cortex.Mediator.Queries;
using FullProject.Domain.Entities;

namespace FullProject.Domain.Queries
{
    public record GetOrders() : IQuery<IList<Order>>;
}
