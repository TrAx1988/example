namespace FullProject.Infrastructure.Data
{
    /// <summary>
    /// Definiert ein generisches Repository zur Verwaltung von Entitäten des Typs <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Der Typ der Entität, die vom Repository verwaltet wird.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gibt alle Entitäten als abfragbare Sammlung zurück.
        /// </summary>
        /// <param name="tracking">Gibt an, ob Änderungen an den Entitäten nachverfolgt werden sollen.</param>
        /// <param name="autoInclude">Gibt an, ob Navigationen geladen werden sollen.</param>
        IQueryable<T> GetAll(bool tracking = true, bool autoInclude = true);

        /// <summary>
        /// Sucht eine Entität anhand der angegebenen Schlüsselwerte.
        /// </summary>
        /// <param name="keyValues">Die Schlüsselwerte der zu suchenden Entität.</param>
        /// <returns>Die gefundene Entität oder null, falls nicht gefunden.</returns>
        T? Find(params object[] keyValues);

        /// <summary>
        /// Sucht asynchron eine Entität anhand der angegebenen Schlüsselwerte.
        /// </summary>
        /// <param name="keyValues">Die Schlüsselwerte der zu suchenden Entität.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        /// <returns>Die gefundene Entität oder null, falls nicht gefunden.</returns>
        ValueTask<T?> FindAsnyc(object[] keyValues, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fügt eine neue Entität hinzu.
        /// </summary>
        /// <param name="entity">Die hinzuzufügende Entität.</param>
        void Add(T entity);

        /// <summary>
        /// Fügt asynchron eine neue Entität hinzu.
        /// </summary>
        /// <param name="entity">Die hinzuzufügende Entität.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fügt mehrere Entitäten hinzu.
        /// </summary>
        /// <param name="entities">Die hinzuzufügenden Entitäten.</param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Fügt mehrere Entitäten asynchron hinzu.
        /// </summary>
        /// <param name="entities">Die hinzuzufügenden Entitäten.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Aktualisiert eine Entität.
        /// </summary>
        /// <param name="entity">Die zu aktualisierende Entität.</param>
        void Update(T entity);

        /// <summary>
        /// Aktualisiert eine Entität asynchron.
        /// </summary>
        /// <param name="entity">Die zu aktualisierende Entität.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Aktualisiert mehrere Entitäten.
        /// </summary>
        /// <param name="entities">Die zu aktualisierenden Entitäten.</param>
        void UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Aktualisiert mehrere Entitäten asynchron.
        /// </summary>
        /// <param name="entities">Die zu aktualisierenden Entitäten.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Entfernt eine Entität.
        /// </summary>
        /// <param name="entity">Die zu entfernende Entität.</param>
        void Remove(T entity);

        /// <summary>
        /// Entfernt mehrere Entitäten.
        /// </summary>
        /// <param name="entities">Die zu entfernenden Entitäten.</param>
        void RemoveRange(IEnumerable<T> entities);

        /// <summary>
        /// Entfernt eine Entität asynchron.
        /// </summary>
        /// <param name="entity">Die zu entfernende Entität.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        Task RemoveAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Entfernt mehrere Entitäten asynchron.
        /// </summary>
        /// <param name="entities">Die zu entfernenden Entitäten.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Definiert ein generisches Repository zur Verwaltung von Entitäten beliebigen Typs.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gibt alle Entitäten des angegebenen Typs als abfragbare Sammlung zurück.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="tracking">Gibt an, ob Änderungen an den Entitäten nachverfolgt werden sollen.</param>
        /// <param name="autoInclude">Gibt an, ob Navigationen geladen werden sollen.</param>
        IQueryable<T> GetAll<T>(bool tracking = true, bool autoInclude = true) where T : class;

        /// <summary>
        /// Sucht eine Entität des angegebenen Typs anhand der Schlüsselwerte.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="keyValues">Die Schlüsselwerte der zu suchenden Entität.</param>
        /// <returns>Die gefundene Entität oder null, falls nicht gefunden.</returns>
        T? Find<T>(params object[] keyValues) where T : class;

        /// <summary>
        /// Sucht asynchron eine Entität des angegebenen Typs anhand der Schlüsselwerte.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="keyValues">Die Schlüsselwerte der zu suchenden Entität.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        /// <returns>Die gefundene Entität oder null, falls nicht gefunden.</returns>
        ValueTask<T?> FindAsnyc<T>(object[] keyValues, CancellationToken cancellationToken = default) where T : class;

        /// <summary>
        /// Fügt eine neue Entität hinzu.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="entity">Die hinzuzufügende Entität.</param>
        void Add<T>(T entity) where T : class;

        /// <summary>
        /// Fügt asynchron eine neue Entität hinzu.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="entity">Die hinzuzufügende Entität.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        Task AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;

        /// <summary>
        /// Fügt mehrere Entitäten hinzu.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="entities">Die hinzuzufügenden Entitäten.</param>
        void AddRange<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Fügt mehrere Entitäten asynchron hinzu.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="entities">Die hinzuzufügenden Entitäten.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        Task AddRangeAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class;

        /// <summary>
        /// Aktualisiert eine Entität.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="entity">Die zu aktualisierende Entität.</param>
        void Update<T>(T entity) where T : class;

        /// <summary>
        /// Aktualisiert eine Entität asynchron.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="entity">Die zu aktualisierende Entität.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        Task UpdateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;

        /// <summary>
        /// Aktualisiert mehrere Entitäten.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="entities">Die zu aktualisierenden Entitäten.</param>
        void UpdateRange<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Aktualisiert mehrere Entitäten asynchron.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="entities">Die zu aktualisierenden Entitäten.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        Task UpdateRangeAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class;

        /// <summary>
        /// Entfernt eine Entität.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="entity">Die zu entfernende Entität.</param>
        void Remove<T>(T entity) where T : class;

        /// <summary>
        /// Entfernt mehrere Entitäten.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="entities">Die zu entfernenden Entitäten.</param>
        void RemoveRange<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Entfernt eine Entität asynchron.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="entity">Die zu entfernende Entität.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        Task RemoveAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;

        /// <summary>
        /// Entfernt mehrere Entitäten asynchron.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="entities">Die zu entfernenden Entitäten.</param>
        /// <param name="cancellationToken">Ein Token zur Überwachung von Abbruchanforderungen.</param>
        Task RemoveRangeAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class;
    }
}