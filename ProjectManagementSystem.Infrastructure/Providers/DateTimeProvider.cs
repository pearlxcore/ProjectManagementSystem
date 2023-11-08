using ProjectManagementSystem.Application.Common.Interfaces.Providers;

namespace ProjectManagementSystem.Infrastructure.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;

        public bool ValidateDateTime(DateTime date)
        {
            var currentDate = DateTime.UtcNow;
            return currentDate <= date;
        }
    }
}
