
using Microsoft.EntityFrameworkCore;

namespace FullProject.Infrastructure.Database
{
    /// <inheritdoc/>
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public Repository(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }

        /// <inheritdoc/>
        public IQueryable<T> GetAll(bool tracking = true)
        {
            if (tracking)
            {
                return _dbSet.AsQueryable();
            }

            return _dbSet.AsQueryable().AsNoTracking();
        }
    }
}
