
using FullProject.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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
        internal readonly DbContext _dbContext;

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

        /// <inheritdoc/>
        public ITransaction BeginTransaction()
        {
            var transaction = _dbContext.Database.BeginTransaction();

            return new Transaction(this, transaction);
        }
    }

    /// <inheritdoc/>
    internal class Transaction : ITransaction
    {
        private readonly Session _session;
        private readonly IDbContextTransaction _transaction;

        public Transaction(Session session, IDbContextTransaction transaction)
        {
            _session = session;
            _transaction = transaction;
        }

        /// <inheritdoc/>
        public void Commit()
        {
            _transaction.Commit();
        }

        /// <inheritdoc/>
        public Task CommitAsync()
        {
            return _transaction.CommitAsync();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _transaction.Dispose();
        }

        /// <inheritdoc/>
        public ValueTask DisposeAsync()
        {
            return _transaction.DisposeAsync();
        }

        /// <inheritdoc/>
        public void Rollback()
        {
            _transaction.Rollback();
        }

        /// <inheritdoc/>
        public Task RollbackAsync()
        {
            return _transaction.RollbackAsync();
        }
    }
}
