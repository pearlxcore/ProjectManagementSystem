using ProjectManagementSystem.Domain.Aggregates.Common.Model;

namespace ProjectManagementSystem.Domain.Aggregates.Users.ValueObjects
{
    public sealed class UserId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public UserId(Guid value)
        {
            Value = value;
        }

        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static UserId Create(Guid value)
        {
            return new(value);
        }
    }
}
