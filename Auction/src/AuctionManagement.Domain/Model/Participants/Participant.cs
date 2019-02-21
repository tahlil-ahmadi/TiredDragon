using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Contracts;
using AuctionManagement.Domain.Framework;

namespace AuctionManagement.Domain.Model.Participants
{
    public class Participant : AggregateRoot<long>
    {
        public string Name { get; private set; }
        public Participant(long id, string name)
        {
            this.Id = id;
            Name = name;
        }
        public override void Apply(DomainEvent @event){ }
    }
}
