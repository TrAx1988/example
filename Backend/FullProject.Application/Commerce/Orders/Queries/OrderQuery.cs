using Cortex.Mediator.Queries;
using FullProject.Domain.Entities;
using FullProject.Domain.Models.Orders;
using FullProject.Domain.Queries;
using FullProject.Domain.UnitOfWork;
using Mapster;

namespace FullProject.Application.Commerce.Orders.Queries
{
    /// <summary>
    /// Stellt einen Handler für das Ereignis <see cref="GetOrders"/> dar.
    /// </summary>
    internal class GetOrdersHandler : IQueryHandler<GetOrders, IList<OrderDto>>
    {
        private readonly ICommerceUnitOfWork _unitOfWork;

        public GetOrdersHandler(ICommerceUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IList<OrderDto>> Handle(GetOrders query, CancellationToken cancellationToken)
        {
            IList<OrderDto> result = _unitOfWork.Repository.GetAll<Order>(false, true).ProjectToType<OrderDto>()
                .ToList();

            return Task.FromResult(result);
        }
    }
}
