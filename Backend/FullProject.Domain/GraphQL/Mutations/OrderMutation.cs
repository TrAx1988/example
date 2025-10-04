using FullProject.Domain.Entities;
using FullProject.Domain.Repository;

namespace FullProject.Domain.GraphQL.Mutations
{
    public interface IOrderMutation
    {
        Task<Order> AddOrder(ICommerceUnitOfWork unitOfWork, Order order);
    }
}
