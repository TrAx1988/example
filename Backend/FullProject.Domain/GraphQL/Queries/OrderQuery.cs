using FullProject.Domain.Entities;
using FullProject.Domain.Repository;

namespace FullProject.Domain.GraphQL.Queries
{
    public interface IOrderQuery
    {
        IQueryable<Order> Orders(ICommerceRepository repository);
    }
}
