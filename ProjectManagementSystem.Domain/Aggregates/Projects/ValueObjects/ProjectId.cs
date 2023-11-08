using ProjectManagementSystem.Domain.Aggregates.Common.Model;

namespace ProjectManagementSystem.Domain.Aggregates.Projects.ValueObjects
{
    public sealed class ProjectId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public ProjectId(Guid value)
        {
            Value=value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static ProjectId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static ProjectId Create(Guid projectId)
        {
            return new(projectId);
        }
    }
}
