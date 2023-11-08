namespace ProjectManagementSystem.Contracts.Task
{
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public List<Guid> AssignedUsers { get; set; }

        public TaskResponse(Guid id, string name, string description, DateTime startDate, DateTime endDate, string status, string priority, List<Guid> assignedUser)
        {
            Id=id;
            Name=name;
            Description=description;
            StartDate=startDate;
            EndDate=endDate;
            Status=status;
            Priority=priority;
            AssignedUsers=assignedUser;
        }
    }
}
