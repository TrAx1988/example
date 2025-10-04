using FullProject.Domain.Repository;
using FullProject.Infrastructure.Database.Ef;

namespace FullProject.Infrastructure.Database.Commerce
{
    internal class CommerceUnitOfWork : UnitOfWork, ICommerceUnitOfWork
    {
        public CommerceUnitOfWork(CommerceContext dbContext) : base(dbContext)
        {
        }
    }
}
