using Cortex.Mediator.Queries;
using FullProject.Domain.Entities;
using FullProject.Domain.Queries;
using FullProject.Infrastructure.Data;

namespace FullProject.Application.Commerce.Orders.Queries
{
    /// <summary>
    /// Stellt einen Handler für das Ereignis <see cref="GetOrders"/> dar.
    /// </summary>
    internal class GetOrdersHandler : IQueryHandler<GetOrders, IList<Order>>
    {
        private readonly IUnitOfWorkFactory _sessionFactory;

        public GetOrdersHandler(IUnitOfWorkFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public Task<IList<Order>> Handle(GetOrders query, CancellationToken cancellationToken)
        {
            using var session = _sessionFactory.CreateUnitOfWork();

            IList<Order> result = session.GetRepository<Order>().GetAll().ToList();

            return Task.FromResult(result);
        }
    }
}
