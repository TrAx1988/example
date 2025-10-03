using FullProject.Domain.Entities;
using FullProject.Domain.GraphQL.Queries;
using FullProject.Infrastructure.Database.Context;
using HotChocolate.Authorization;

namespace FullProject.Infrastructure.GraphQL.Query
{
    [Authorize]
    public class OrderQuery : IOrderQuery
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Order> Orders([Service] CommerceContext commerceContext)
        {
            return commerceContext.Orders;
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Order> Orders(IRepository<Order> repository)
        {
            throw new NotImplementedException();
        }
    }
}
