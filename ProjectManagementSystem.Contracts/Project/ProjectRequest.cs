namespace ProjectManagementSystem.Contracts.Projects
{
    public record CreateProjectRequest(
        Guid Id,
        string Name,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        string Status,
        string Priority,
        decimal Budget,
        List<Guid> TeamMembers,
        Guid ClientId);
}
