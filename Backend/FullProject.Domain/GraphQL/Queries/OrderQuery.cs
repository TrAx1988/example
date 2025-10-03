using FullProject.Domain.Entities;
using FullProject.Infrastructure;

namespace FullProject.Domain.GraphQL.Queries
{
    /// <summary>
    /// Defines a query operation for retrieving orders from a data repository.
    /// </summary>
    /// <remarks>This interface provides a method to construct a queryable sequence of orders based on the
    /// specified repository. The implementation determines the specific query logic applied to the
    /// repository.</remarks>
    public interface IOrderQuery
    {
        /// <summary>
        /// Retrieves a queryable collection of orders from the specified repository.
        /// </summary>
        /// <param name="repository">The repository from which to retrieve the orders. Must not be <see langword="null"/>.</param>
        /// <returns>An <see cref="IQueryable{T}"/> representing the collection of orders.</returns>
        IQueryable<Order> Orders(IRepository<Order> repository);
    }
}
