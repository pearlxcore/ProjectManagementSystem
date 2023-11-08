using ProjectManagementSystem.Domain.Aggregates.Common.Model;
using ProjectManagementSystem.Domain.Aggregates.Task.ValueObjects;
using ProjectManagementSystem.Domain.Aggregates.Users.ValueObjects;

namespace ProjectManagementSystem.Domain.Aggregates.Task
{
    public sealed class Task : AggregateRoot<TaskId, Guid>
    {
        private readonly List<UserId> _assignedUserIds;
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Status { get; private set; }
        public string Priority { get; private set; }
        public List<UserId> AssignedUserIds => _assignedUserIds;

        private Task(
            TaskId taskId,
            string name,
            string description,
            DateTime startDate,
            DateTime endDate,
            string status,
            string priority,
            List<UserId> assignedUserIds) : base(taskId)
        {
            _assignedUserIds=assignedUserIds ?? new();
            Name=name;
            Description=description;
            StartDate=startDate;
            EndDate=endDate;
            Status=status;
            Priority=priority;
        }

        public class Factory
        {
            public static Task Create(
            string name,
            string description,
            DateTime startDate,
            DateTime endDate,
            string status,
            string priority,
            List<UserId> assignedUserIds)
            {
                return new(
                    TaskId.CreateUnique(),
                    name,
                    description,
                    startDate,
                    endDate,
                    status,
                    priority,
                    assignedUserIds);
            }
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Task()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}
