using Cortex.Mediator.Queries;
using FullProject.Domain.Entities;
using FullProject.Domain.Queries;
using FullProject.Domain.Repository;

namespace FullProject.Application.Commerce.Orders.Queries
{
    /// <summary>
    /// Stellt einen Handler für das Ereignis <see cref="GetOrders"/> dar.
    /// </summary>
    internal class GetOrdersHandler : IQueryHandler<GetOrders, IList<Order>>
    {
        private readonly ICommerceUnitOfWork _unitOfWork;

        public GetOrdersHandler(ICommerceUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IList<Order>> Handle(GetOrders query, CancellationToken cancellationToken)
        {
            IList<Order> result = _unitOfWork.Repository.GetAll<Order>(false, true)
                .ToList();

            return Task.FromResult(result);
        }
    }
}
