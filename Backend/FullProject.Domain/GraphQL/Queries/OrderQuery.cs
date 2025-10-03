using FullProject.Domain.Entities;
using FullProject.Infrastructure;

namespace FullProject.Domain.GraphQL.Queries
{
    public interface IOrderQuery
    {
        IQueryable<Order> Orders(IRepository<Order> repository);
    }
}
