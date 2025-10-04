namespace FullProject.Infrastructure.Data
{
    /// <summary>
    /// Sitzungsfabrik zum Erstellen einer Datenbanksitzung.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Erstellt und gibt eine neue Sitzung zur Interaktion mit der Datenbank zurück.
        /// </summary>
        /// <remarks>
        /// Die zurückgegebene Sitzung stellt Methoden und Eigenschaften zur Verwaltung
        /// von datenbankspezifischen Operationen bereit. Stelle sicher, dass die Sitzung ordnungsgemäß entsorgt wird,
        /// wenn sie nicht mehr benötigt wird, um alle zugehörigen Ressourcen freizugeben.
        /// </remarks>
        /// <returns>Ein Objekt, das das <see cref="IUnitOfWork"/>-Interface implementiert und die neu erstellte Sitzung repräsentiert.</returns>
        IUnitOfWork CreateUnitOfWork();
    }

    /// <summary>
    /// Definiert einen Vertrag zur Verwaltung einer Transaktion, sodass Änderungen bestätigt oder zurückgesetzt werden können.
    /// </summary>
    /// <remarks>
    /// Implementierungen dieses Interfaces bieten Mechanismen, um die Atomizität von Operationen innerhalb
    /// einer Transaktion sicherzustellen. Transaktionen können bestätigt werden, um Änderungen dauerhaft zu machen,
    /// oder zurückgesetzt werden, um Änderungen rückgängig zu machen. Dieses Interface unterstützt sowohl synchrone
    /// als auch asynchrone Operationen und implementiert <see cref="IDisposable"/> und
    /// <see cref="IAsyncDisposable"/>, um eine ordnungsgemäße Ressourcenfreigabe zu gewährleisten.
    /// </remarks>
    public interface ITransaction : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Bestätigt die Transaktion und macht alle Änderungen dauerhaft.
        /// </summary>
        void Commit();
        /// <summary>
        /// Bestätigt die Transaktion asynchron und macht alle Änderungen dauerhaft.
        /// </summary>
        /// <returns>Ein Task, der die asynchrone Commit-Operation repräsentiert.</returns>
        Task CommitAsync();
        /// <summary>
        /// Setzt die Transaktion zurück und macht alle während der Transaktion vorgenommenen Änderungen rückgängig.
        /// </summary>
        void Rollback();
        /// <summary>
        /// Setzt die Transaktion asynchron zurück und macht alle während der Transaktion vorgenommenen Änderungen rückgängig.
        /// </summary>
        /// <returns>Ein Task, der die asynchrone Rollback-Operation repräsentiert.</returns>
        Task RollbackAsync();
    }

    /// <summary>
    /// Sitzung für Datenbankoperationen.
    /// </summary>
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Aktuelles Repository zur Verwaltung von Entitäten.
        /// </summary>
        IRepository Repository { get; }

        /// <summary>
        /// Speichert Änderungen in der Datenbank.
        /// </summary>
        void Save();

        /// <summary>
        /// Speichert den aktuellen Zustand oder die Daten asynchron im zugrunde liegenden Speicher.
        /// </summary>
        /// <remarks>
        /// Diese Methode führt den Speichervorgang asynchron aus, sodass der aufrufende Thread nicht blockiert wird.
        /// Es liegt in der Verantwortung des Aufrufers, sicherzustellen, dass alle erforderlichen Daten vor dem Aufruf dieser Methode vorbereitet sind.
        /// </remarks>
        /// <returns>Ein Task, der die asynchrone Speicheroperation repräsentiert.</returns>
        Task SaveAsync();

        /// <summary>
        /// Startet eine neue Transaktion.
        /// </summary>
        /// <remarks>
        /// Die zurückgegebene Transaktion muss bestätigt oder zurückgesetzt werden, um die Operation abzuschließen.
        /// Stelle sicher, dass die Transaktion ordnungsgemäß entsorgt wird, um alle zugehörigen Ressourcen freizugeben.
        /// </remarks>
        /// <returns>Eine <see cref="ITransaction"/>-Instanz, die die neu gestartete Transaktion repräsentiert.</returns>
        ITransaction BeginTransaction();

        /// <summary>
        /// Gibt eine Repository-Instanz für den angegebenen Entitätstyp zurück.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität, für die das Repository angefordert wird. Muss ein Referenztyp sein.</typeparam>
        /// <returns>Eine Instanz von <see cref="IRepository{T}"/> zur Verwaltung von Entitäten des Typs <typeparamref name="T"/>.</returns>
        IRepository<T> GetRepository<T>() where T : class;
    }
}