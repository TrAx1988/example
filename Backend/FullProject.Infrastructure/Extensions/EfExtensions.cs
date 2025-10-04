using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FullProject.Infrastructure.Extensions
{
    public static class EfExtensions
    {
        /// <summary>
        /// Fügt mehrere Include-Ausdrücke zu einer Abfrage hinzu, um verwandte Entitäten mitzuladen.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <param name="source">Die ursprüngliche Abfrage.</param>
        /// <param name="includes">Die zu ladenden Navigationseigenschaften.</param>
        /// <returns>Die Abfrage mit den angegebenen Includes.</returns>
        public static IQueryable<T> IncludeNavigation<T>(this IQueryable<T> source, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    source = source.Include(include);

                }
            }
            return source;
        }

        /// <summary>
        /// Fügt ein ThenInclude zu einer Abfrage hinzu, um verschachtelte Navigationseigenschaften mitzuladen.
        /// </summary>
        /// <typeparam name="T">Der Typ der Entität.</typeparam>
        /// <typeparam name="TPreviousProperty">Der Typ der vorherigen Navigationseigenschaft.</typeparam>
        /// <typeparam name="TProperty">Der Typ der aktuellen Navigationseigenschaft.</typeparam>
        /// <param name="source">Die ursprüngliche Abfrage.</param>
        /// <param name="previousProperty">Die vorherige Navigationseigenschaft.</param>
        /// <param name="property">Die aktuelle Navigationseigenschaft, die geladen werden soll.</param>
        /// <returns>Die Abfrage mit dem angegebenen ThenInclude.</returns>
        public static IQueryable<T> ThenIncludeNavigation<T, TPreviousProperty, TProperty>(this IQueryable<T> source, Expression<Func<T, TPreviousProperty>> previousProperty, Expression<Func<TPreviousProperty, TProperty>> property) where T : class where TPreviousProperty : class
        {
            return source.Include(previousProperty).ThenInclude(property);
        }
    }
}
