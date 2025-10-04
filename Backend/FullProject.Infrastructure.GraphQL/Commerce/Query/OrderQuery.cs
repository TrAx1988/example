using FullProject.Domain.Entities;
using FullProject.Domain.GraphQL.Queries;
using FullProject.Domain.Models.Orders;
using FullProject.Domain.Repository;
using HotChocolate.Authorization;
using Mapster;
using MapsterMapper;

namespace FullProject.Infrastructure.GraphQL.Commerce.Query
{
    /// <inheritdoc/>
    [Authorize]
    public class OrderQuery : IOrderQuery
    {
        private readonly IMapper _mapper;

        public OrderQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc/>
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLType(typeof(List<OrderDto>))]
        public IQueryable<OrderDto> Orders([Service] ICommerceRepository repository)
        {
            return repository.GetAll<Order>(false).ProjectToType<OrderDto>();
        }
    }
}
