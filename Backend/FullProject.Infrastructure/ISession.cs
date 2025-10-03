namespace FullProject.Infrastructure
{
    /// <summary>
    /// Session Factory to create a database session.
    /// </summary>
    public interface ISessionFactory
    {
        /// <summary>
        /// Creates and returns a new session for interacting with the database.
        /// </summary>
        /// <remarks>The returned session provides methods and properties for managing
        /// database-specific operations. Ensure proper disposal of the session when it is no longer needed to
        /// release any associated resources.</remarks>
        /// <returns>An object implementing the <see cref="ISession"/> interface, representing the newly created session.</returns>
        ISession CreateSession();
    }

    /// <summary>
    /// Session for database operations.
    /// </summary>
    public interface ISession : IDisposable, IAsyncDisposable
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
        /// Retrieves a repository instance for the specified entity type.
        /// </summary>
        /// <typeparam name="T">The type of the entity for which the repository is requested. Must be a reference type.</typeparam>
        /// <returns>An instance of <see cref="IRepository{T}"/> for managing entities of type <typeparamref name="T"/>.</returns>
        IRepository<T> GetRepository<T>() where T : class;
    }
}
