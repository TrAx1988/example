using FullProject.Infrastructure.Data;
using FullProject.Infrastructure.Database.Commerce;
using FullProject.Infrastructure.Database.Ef;

namespace FullProject.Infrastructure.Database.Extensions
{
    public static class UnitOfWorkExtensions
    {
        public static IUnitOfWork CreateCommercialUnitOfWork(this IUnitOfWorkFactory factory)
        {
            return new UnitOfWork(new CommerceContext());
        }
    }
}
