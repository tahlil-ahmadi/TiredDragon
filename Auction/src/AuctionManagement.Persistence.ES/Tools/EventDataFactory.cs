using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuctionManagement.Domain.Contracts;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace AuctionManagement.Persistence.ES.Tools
{
    public static class EventDataFactory
    {
        public static List<EventData> CreateFromEvents(IEnumerable<DomainEvent> events)
        {
            return events.Select(CreateOne).ToList();
        }

        private static EventData CreateOne(DomainEvent eventItem)
        {
            var type = eventItem.GetType().AssemblyQualifiedName;
            var json = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(eventItem));
            return new EventData(eventItem.EventId, type, true,json,null);
        }
    }
}
