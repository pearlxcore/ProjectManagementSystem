using ProjectManagementSystem.Domain.Aggregates.Common.Model;
using ProjectManagementSystem.Domain.Aggregates.Projects.ValueObjects;
using ProjectManagementSystem.Domain.Aggregates.Task.ValueObjects;
using ProjectManagementSystem.Domain.Aggregates.Users.ValueObjects;


namespace ProjectManagementSystem.Domain.Aggregates.Projects
{
    public sealed class Project : AggregateRoot<ProjectId, Guid>
    {
        private readonly List<UserId> _userIds;
        private readonly List<TaskId> _taskIds;

        public string Name { get; internal set; }
        public string Description { get; protected set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Status { get; protected set; }
        public string Priority { get; private set; }
        public decimal Budget { get; private set; }
        public Guid ClientId { get; private set; }
        public List<TaskId> TaskIds => _taskIds;

        private Project(
            ProjectId projectId,
            string name,
            string description,
            DateTime startDate,
            DateTime endDate,
            string status,
            string priority,
            decimal budget,
            List<UserId> assignedUsers,
            Guid clientId) : base(projectId)
        {
            Name=name;
            Description=description;
            StartDate=startDate;
            EndDate=endDate;
            Status=status;
            Priority=priority;
            Budget=budget;
            _userIds=assignedUsers ?? new();
            ClientId=clientId;
            _taskIds=new();
        }

        public class Factory
        {
            public static Project Create(
                string name,
                string description,
                DateTime startDate,
                DateTime endDate,
                string status,
                string priority,
                decimal budget,
                List<UserId> assignedUsers,
                Guid clientId)
            {
                return new(
                    ProjectId.CreateUnique(),
                    name,
                    description,
                    startDate,
                    endDate,
                    status,
                    priority,
                    budget,
                    assignedUsers,
                    clientId);
            }
        }

        private Project()
        {

        }
    }
}
