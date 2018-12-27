using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionManagement.Domain.Contracts
{
    public abstract class DomainEvent
    {
        public Guid EventId { get; private set; }
        public DateTime EventPublishDateTime { get;private set; }
        protected DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            this.EventPublishDateTime = DateTime.Now;
        }
    }
}
