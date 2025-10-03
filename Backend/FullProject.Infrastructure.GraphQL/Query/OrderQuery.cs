using FullProject.Domain.Entities;
using FullProject.Infrastructure.Database.Context;
using HotChocolate.Authorization;

namespace FullProject.Infrastructure.GraphQL.Query
{
    [Authorize]
    public class OrderQuery
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Order> Orders([Service] CommerceContext commerceContext)
        {
            return commerceContext.Orders;
        }
    }
}
