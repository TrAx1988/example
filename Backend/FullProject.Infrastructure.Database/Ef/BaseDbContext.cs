using FullProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FullProject.Infrastructure.Database.Ef
{
    public abstract class BaseDbContext : DbContext, IRepository
    {
        public BaseDbContext()
        {
        }

        public BaseDbContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <inheritdoc/>
        public void AddRange<T>(IEnumerable<T> entities) where T : class
        {
            Set<T>().AddRange(entities);
        }

        /// <inheritdoc/>
        public Task AddRangeAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {
            return Set<T>().AddRangeAsync(entities, cancellationToken);
        }

        /// <inheritdoc/>
        public ValueTask<T?> FindAsnyc<T>(object[] keyValues, CancellationToken cancellationToken = default) where T : class
        {
            return Set<T>().FindAsync(keyValues, cancellationToken);
        }

        /// <inheritdoc/>
        public IQueryable<T> GetAll<T>(bool tracking = true) where T : class
        {
            return tracking ? Set<T>().AsQueryable() : Set<T>().AsNoTracking();
        }

        /// <inheritdoc/>
        public Task RemoveAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
        {
            Set<T>().Remove(entity);

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public void RemoveRange<T>(IEnumerable<T> entities) where T : class
        {
            Set<T>().RemoveRange(entities);
        }

        /// <inheritdoc/>
        public Task RemoveRangeAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {
            Set<T>().RemoveRange(entities);

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task UpdateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
        {
            Set<T>().Update(entity);

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            Set<T>().UpdateRange(entities);
        }

        /// <inheritdoc/>
        public Task UpdateRangeAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {
            Set<T>().UpdateRange(entities);

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        void IRepository.Add<T>(T entity)
        {
            Set<T>().Add(entity);

        }

        /// <inheritdoc/>
        Task IRepository.AddAsync<T>(T entity, CancellationToken cancellationToken)
        {
            return Set<T>().AddAsync(entity, cancellationToken).AsTask();
        }

        /// <inheritdoc/>
        void IRepository.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        /// <inheritdoc/>
        void IRepository.Update<T>(T entity)
        {
            Set<T>().Update(entity);
        }
    }
}
