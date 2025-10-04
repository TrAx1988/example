using FullProject.Infrastructure.Data;
using FullProject.Infrastructure.Database.Commerce;
using Microsoft.EntityFrameworkCore.Storage;

namespace FullProject.Infrastructure.Database.Ef
{
    /// <inheritdoc/>
    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public UnitOfWorkFactory()
        {
        }

        /// <inheritdoc/>
        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(new CommerceContext());
        }
    }

    /// <inheritdoc/>
    internal class UnitOfWork : IUnitOfWork
    {
        internal readonly BaseDbContext _dbContext;

        /// <inheritdoc/>
        public IRepository Repository => _dbContext;

        public UnitOfWork(BaseDbContext dbContext)
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
        private readonly UnitOfWork _unitOfWork;
        private readonly IDbContextTransaction _transaction;

        public Transaction(UnitOfWork unitOfWork, IDbContextTransaction transaction)
        {
            _unitOfWork = unitOfWork;
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
