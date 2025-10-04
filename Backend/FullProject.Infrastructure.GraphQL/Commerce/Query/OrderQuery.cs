using FullProject.Domain.Entities;
using FullProject.Domain.GraphQL.Queries;
using FullProject.Domain.Repository;
using HotChocolate.Authorization;
using MapsterMapper;

namespace FullProject.Infrastructure.GraphQL.Commerce.Query
{
    /// <inheritdoc/>
    [Authorize]
    public class OrderQuery : IOrderQuery
    {
        public OrderQuery(IMapper mapper)
        {
        }

        /// <inheritdoc/>
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Order> Orders([Service] ICommerceUnitOfWork unitOfWork)
        {
            return unitOfWork.Repository.GetAll<Order>(false, false);
        }
    }
}
