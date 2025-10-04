using FullProject.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace FullProject.Infrastructure.Database.Context
{
    public partial class CommerceContext : ICommerceRepository, IRepository
    {
        public IQueryable<T> GetAll<T>(bool tracking = true) where T : class
        {
            if (tracking)
            {
                return Set<T>().AsQueryable();
            }

            return Set<T>().AsNoTracking();
        }
    }
}
