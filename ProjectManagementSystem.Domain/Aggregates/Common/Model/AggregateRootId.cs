namespace ProjectManagementSystem.Domain.Aggregates.Common.Model
{
    public abstract class AggregateRootId<TIdType> : ValueObject
    {
        public abstract TIdType Value { get; protected set; }
    }
}
