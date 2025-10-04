using FullProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FullProject.Infrastructure.Database.Ef
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
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <inheritdoc/>
        public Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            return _dbSet.AddAsync(entity, cancellationToken).AsTask();
        }

        /// <inheritdoc/>
        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        /// <inheritdoc/>
        public Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            return _dbSet.AddRangeAsync(entities, cancellationToken);
        }

        /// <inheritdoc/>
        public T? Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        /// <inheritdoc/>
        public ValueTask<T?> FindAsnyc(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return _dbSet.FindAsync(keyValues, cancellationToken);
        }

        /// <inheritdoc/>
        public IQueryable<T> GetAll(bool tracking = true, bool autoInclude = true)
        {
            var query = tracking ? _dbSet : _dbSet.AsNoTracking();

            if (!autoInclude)
            {
                query = query.IgnoreAutoIncludes();
            }

            return query;
        }

        /// <inheritdoc/>
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <inheritdoc/>
        public Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        /// <inheritdoc/>
        public Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _dbSet.RemoveRange(entities);

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        /// <inheritdoc/>
        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        /// <inheritdoc/>
        public Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _dbSet.UpdateRange(entities);

            return Task.CompletedTask;
        }
    }
}