
using FullProject.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace FullProject.Infrastructure.Database
{
    /// <inheritdoc/>
    internal class SessionFactory : ISessionFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SessionFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public ISession CreateSession()
        {
            return new Session(new CommerceContext());
        }
    }

    /// <inheritdoc/>
    internal class Session : ISession
    {
        private readonly DbContext _dbContext;

        public Session(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        /// <inheritdoc/>
        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        /// <inheritdoc/>
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public Task SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_dbContext.Set<T>());
        }
    }
}
