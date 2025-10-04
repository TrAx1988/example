using FullProject.Domain.Entities;
using FullProject.Domain.Models.Orders;
using Mapster;

namespace FullProject.Application.Commerce.Mapping
{
    public class OrderConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Order, OrderDto>();
        }
    }
}