namespace FullProject.Infrastructure
{

    public interface ITimeService
    {
        /// <summary>
        /// Gibt das aktuelle Datum und die aktuelle Uhrzeit zurück.
        /// </summary>
        /// <returns>Das aktuelle <see cref="DateTime"/>.</returns>
        DateTime GetCurrentDateTime();
    }

    /// <inheritdoc/>
    internal class TimeService : ITimeService
    {
        /// <inheritdoc/>
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
