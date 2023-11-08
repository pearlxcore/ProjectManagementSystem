﻿namespace ProjectManagementSystem.Domain.Aggregates.Common.Model
{
    public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
        where TId : AggregateRootId<TIdType>
    {
        public new AggregateRootId<TIdType> Id { get; protected set; }
        protected AggregateRoot(TId id)
        {
            Id = id;
        }
        protected AggregateRoot() { }
    }
}
