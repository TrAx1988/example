using Cortex.Mediator.Queries;
using FullProject.Domain.Entities;
using FullProject.Infrastructure;

namespace FullProject.Application.Orders.Queries
{
    public record GetOrders() : IQuery<IList<Order>>;

    internal class GetOrdersHandler : IQueryHandler<GetOrders, IList<Order>>
    {
        private readonly ISessionFactory _sessionFactory;

        public GetOrdersHandler(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public Task<IList<Order>> Handle(GetOrders query, CancellationToken cancellationToken)
        {
            using var session = _sessionFactory.CreateSession();

            IList<Order> result = session.GetRepository<Order>().GetAll().ToList();

            return Task.FromResult(result);
        }
    }
}
