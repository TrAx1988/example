using FullProject.Domain.Entities;
using FullProject.Domain.GraphQL.Queries;
using FullProject.Domain.Repository;
using HotChocolate.Authorization;

namespace FullProject.Infrastructure.GraphQL.Query
{
    [Authorize]
    /// <inheritdoc/>
    public class OrderQuery : IOrderQuery
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        /// <inheritdoc/>
        public IQueryable<Order> Orders([Service] ICommerceRepository repository)
        {
            return repository.GetAll<Order>(false);
        }
    }
}
