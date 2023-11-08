namespace ProjectManagementSystem.Contracts.Task
{
    public record TaskRequest(
        string Name,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        string Status,
        string Priority,
        List<Guid> AssignedUsers);
}
