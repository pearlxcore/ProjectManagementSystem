namespace ProjectManagementSystem.Application.Common.Interfaces.Providers
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
        bool ValidateDateTime(DateTime date);
    }
}
