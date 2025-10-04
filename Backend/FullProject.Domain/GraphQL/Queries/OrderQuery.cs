using FullProject.Domain.Models.Orders;
using FullProject.Domain.Repository;

namespace FullProject.Domain.GraphQL.Queries
{
    /// <summary>
    /// Definiert eine Schnittstelle für Abfragen von Bestellungen im GraphQL-Kontext.
    /// </summary>
    public interface IOrderQuery
    {
        /// <summary>
        /// Gibt eine abfragbare Sammlung von Bestellungen zurück.
        /// </summary>
        /// <param name="repository">Das Repository, das für den Datenzugriff verwendet wird.</param>
        /// <returns>Eine <see cref="IQueryable{OrderDto}"/>-Sammlung aller Bestellungen.</returns>
        IQueryable<OrderDto> Orders(ICommerceRepository repository);
    }
}