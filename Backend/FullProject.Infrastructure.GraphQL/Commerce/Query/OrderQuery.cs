using FullProject.Domain.Entities;
using FullProject.Domain.UnitOfWork;
using HotChocolate.Authorization;

namespace FullProject.Infrastructure.GraphQL.Commerce.Query
{
    [Authorize]
    public class OrderQuery
    {
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
