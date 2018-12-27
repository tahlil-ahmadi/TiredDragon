using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Contracts;

namespace AuctionManagement.Domain.Model
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>
    {
        private List<DomainEvent> _uncommittedChanges;
        protected AggregateRoot()
        {
            this._uncommittedChanges = new List<DomainEvent>();
        }
        public void Publish(DomainEvent domainEvent)
        {
            this._uncommittedChanges.Add(domainEvent);
        }
        public IReadOnlyCollection<DomainEvent> GetUncommittedChanges()
        {
            return _uncommittedChanges.AsReadOnly();
        }

        public abstract void Apply(DomainEvent @event);
    }
}
