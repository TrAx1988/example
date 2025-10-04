using FullProject.Infrastructure.Data;

namespace FullProject.Domain.UnitOfWork
{
    /// <summary>
    /// Sitzung für Datenbankoperationen im Commerce.
    /// </summary>
    public interface ICommerceUnitOfWork : IUnitOfWork
    {

    }

    /// <summary>
    /// Repository für den Commerce-Kontext.
    /// </summary>
    public interface ICommerceRepository : IRepository
    {
    }
}
