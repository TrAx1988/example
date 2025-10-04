namespace FullProject.Infrastructure
{
    /// <summary>
    /// Defines a generic repository for managing entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <remarks>This interface provides a contract for data access operations, such as retrieving entities.
    /// Implementations of this interface are expected to handle the underlying data source and provide a consistent API
    /// for interacting with entities of type <typeparamref name="T"/>.</remarks>
    /// <typeparam name="T">The type of entity managed by the repository. Must be a reference type.</typeparam>
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(bool tracking = true);
    }

    /// <summary>
    /// Defines a generic repository for managing entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <remarks>This interface provides a contract for data access operations, such as retrieving entities.
    /// Implementations of this interface are expected to handle the underlying data source and provide a consistent API
    /// for interacting with entities of type <typeparamref name="T"/>.</remarks>
    /// <typeparam name="T">The type of entity managed by the repository. Must be a reference type.</typeparam>
    public interface IRepository
    {
        /// <summary>
        /// Retrieves all entities of type <typeparamref name="T"/> as a queryable collection.
        /// </summary>
        /// <remarks>The returned <see cref="IQueryable{T}"/> allows for further filtering, sorting, and
        /// projection using LINQ queries. The query is not executed until the resulting queryable is
        /// enumerated.</remarks>
        /// <returns>An <see cref="IQueryable{T}"/> representing all entities of type <typeparamref name="T"/>.</returns>
        IQueryable<T> GetAll<T>(bool tracking = true) where T : class;
    }
}
