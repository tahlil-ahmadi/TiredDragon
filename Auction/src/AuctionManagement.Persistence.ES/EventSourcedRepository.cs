using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AuctionManagement.Domain.Model;
using AuctionManagement.Persistence.ES.Tools;
using EventStore.ClientAPI;

namespace AuctionManagement.Persistence.ES
{
    public abstract class EventSourcedRepository<T,TKey> where T : AggregateRoot<TKey>
    {
        public T Get(TKey id)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync().Wait();
            var streamId = GetStreamId(id);

            //TODO: fix this 
            var streamEvents = connection.ReadStreamEventsForwardAsync(streamId, 0, 99, false).Result;

            var domainEvents = DomainEventFactory.Create(streamEvents.Events);

            var aggregate = (T)Activator.CreateInstance(typeof(T), true);
            domainEvents.ForEach(a => aggregate.Apply(a));
            return aggregate;
        }

        public void Add(T aggregate)
        {
            var changes = aggregate.GetUncommittedChanges();

            using (var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113)))
            {
                connection.ConnectAsync().Wait();
                var eventData = EventDataFactory.CreateFromEvents(changes);
                var streamId = GetStreamId(aggregate.Id);
                connection.AppendToStreamAsync(streamId, ExpectedVersion.Any, eventData).Wait();
                connection.Close(); 
            }
        }

        private string GetStreamId(TKey id)
        {
            var name = typeof(T).Name;
            return $"{name}-{id}";
        }
    }
}
