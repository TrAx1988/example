namespace FullProject.Infrastructure
{
    /// <summary>
    /// Session Factory to create a database session.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates and returns a new session for interacting with the database.
        /// </summary>
        /// <remarks>The returned session provides methods and properties for managing
        /// database-specific operations. Ensure proper disposal of the session when it is no longer needed to
        /// release any associated resources.</remarks>
        /// <returns>An object implementing the <see cref="ISession"/> interface, representing the newly created session.</returns>
        IUnitOfWork CreateUnitOfWork();
    }

    /// <summary>
    /// Defines a contract for managing a transactional operation, allowing changes to be committed or rolled back.
    /// </summary>
    /// <remarks>Implementations of this interface provide mechanisms to ensure atomicity of operations within
    /// a transaction. Transactions can be committed to make changes permanent or rolled back to undo changes. This
    /// interface supports both synchronous and asynchronous operations, and implements <see cref="IDisposable"/>  and
    /// <see cref="IAsyncDisposable"/> to ensure proper resource cleanup.</remarks>
    public interface ITransaction : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Commits the transaction, making all changes permanent.
        /// </summary>
        void Commit();
        /// <summary>
        /// Asynchronously commits the transaction, making all changes permanent.
        /// </summary>
        /// <returns>A task that represents the asynchronous commit operation.</returns>
        Task CommitAsync();
        /// <summary>
        /// Rolls back the transaction, undoing all changes made during the transaction.
        /// </summary>
        void Rollback();
        /// <summary>
        /// Asynchronously rolls back the transaction, undoing all changes made during the transaction.
        /// </summary>
        /// <returns>A task that represents the asynchronous rollback operation.</returns>
        Task RollbackAsync();
    }

    /// <summary>
    /// Session for database operations.
    /// </summary>
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Save changes to the database.
        /// </summary>
        void Save();

        /// <summary>
        /// Asynchronously saves the current state or data to the underlying storage.
        /// </summary>
        /// <remarks>This method performs the save operation asynchronously, ensuring that the calling
        /// thread is not blocked. It is the caller's responsibility to ensure that any required data is prepared before
        /// invoking this method.</remarks>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveAsync();

        /// <summary>
        /// Begins a new transaction.
        /// </summary>
        /// <remarks>The returned transaction must be committed or rolled back to complete the operation. 
        /// Ensure proper disposal of the transaction to release any associated resources.</remarks>
        /// <returns>An <see cref="ITransaction"/> instance representing the newly started transaction.</returns>
        ITransaction BeginTransaction();

        /// <summary>
        /// Retrieves a repository instance for the specified entity type.
        /// </summary>
        /// <typeparam name="T">The type of the entity for which the repository is requested. Must be a reference type.</typeparam>
        /// <returns>An instance of <see cref="IRepository{T}"/> for managing entities of type <typeparamref name="T"/>.</returns>
        IRepository<T> GetRepository<T>() where T : class;
    }
}
