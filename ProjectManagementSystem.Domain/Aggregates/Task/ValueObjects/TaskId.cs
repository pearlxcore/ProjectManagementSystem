using ProjectManagementSystem.Domain.Aggregates.Common.Model;

namespace ProjectManagementSystem.Domain.Aggregates.Task.ValueObjects
{
    public sealed class TaskId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }
        public TaskId(Guid value)
        {
            Value=value;
        }

        public static TaskId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static TaskId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
