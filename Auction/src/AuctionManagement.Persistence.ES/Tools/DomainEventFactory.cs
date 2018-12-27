using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuctionManagement.Domain.Contracts;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace AuctionManagement.Persistence.ES.Tools
{
    public static class DomainEventFactory
    {
        public static List<DomainEvent> Create(ResolvedEvent[] events)
        {
            return events.Select(a=> CreateOne(a.Event)).ToList();
        }
        private static DomainEvent CreateOne(RecordedEvent eventItem)
        {
            var json = Encoding.UTF8.GetString(eventItem.Data);
            var type = Type.GetType(eventItem.EventType);
            return (DomainEvent)JsonConvert.DeserializeObject(json, type);
        }
    }
}
