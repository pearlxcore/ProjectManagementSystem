using ProjectManagementSystem.Domain.Aggregates.Common.Model;

namespace ProjectManagementSystem.Domain.Aggregates.Clients.ValueObjects
{
    public sealed class ClientId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }
        private ClientId(Guid value)
        {
            Value = value;
        }

        public static ClientId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static ClientId Create(Guid value)
        {
            return new(value);
        }
    }
}
