using Cortex.Mediator.Queries;
using FullProject.Domain.Entities;
using FullProject.Domain.Queries;
using FullProject.Infrastructure.Data;
using FullProject.Infrastructure.Database.Extensions;
using FullProject.Infrastructure.Extensions;

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
            using var session = _sessionFactory.CreateCommercialUnitOfWork();

            IList<Order> result = session.Repository.GetAll<Order>()
                .IncludeNavigation(p => p.OrderItems)
                .IncludeNavigation(p => p.Customer)
                .ThenIncludeNavigation(p => p.Customer, p => p.Addresses)
                .ToList();

            return Task.FromResult(result);
        }
    }
}
