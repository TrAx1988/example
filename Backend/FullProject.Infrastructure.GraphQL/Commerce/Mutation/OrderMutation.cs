using FullProject.Domain.Entities;
using FullProject.Domain.UnitOfWork;
using HotChocolate.Authorization;

namespace FullProject.Infrastructure.GraphQL.Commerce.Mutation
{
    [Authorize]
    public class OrderMutation
    {
        public Task<Order> AddOrder([Service] ICommerceUnitOfWork unitOfWork, Order order)
        {
            unitOfWork.GetRepository<Order>().Add(order);

            unitOfWork.Commit();

            return Task.FromResult(order);
        }
    }
}
