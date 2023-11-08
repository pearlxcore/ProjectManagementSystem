namespace ProjectManagementSystem.Contracts.Project
{
    public class ProjectResponse
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string Status { get; }
        public string Priority { get; }
        public decimal Budget { get; }
        public Guid ClientId { get; }
        public List<Guid> TaskIds { get; }

        public ProjectResponse(
            Guid id,
            string name,
            string description,
            DateTime startDate,
            DateTime endDate,
            string status,
            string priority,
            decimal budget,
            Guid clientId,
            List<Guid> taskIds)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            Priority = priority;
            Budget = budget;
            ClientId = clientId;
            TaskIds=taskIds;
        }
    }
}
