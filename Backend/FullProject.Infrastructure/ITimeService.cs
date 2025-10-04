namespace FullProject.Infrastructure
{
    public interface ITimeService
    {
        DateTime GetCurrentDateTime();
    }

    internal class TimeService : ITimeService
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
