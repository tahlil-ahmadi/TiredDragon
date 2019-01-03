using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Contracts;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using Newtonsoft.Json;
using NServiceBus;

namespace Syncs.BusDispatcher
{
    class Program
    {
        private static IEndpointInstance bus;
        static void Main(string[] args)
        {
            bus = EndpointConfig.Config();

            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync().Wait();

            var credential = new UserCredentials("admin", "changeit");
            //TODO: change to catch-up subscription
            connection.SubscribeToAllAsync(false, EventAppeared, SubscriptionDropped, credential).Wait();

            Console.WriteLine("Subscription started !");
            Console.ReadLine();
        }

        private static void SubscriptionDropped(EventStoreSubscription arg1, SubscriptionDropReason arg2, Exception arg3)
        {
            //...
        }
        private static async Task EventAppeared(EventStoreSubscription arg1, ResolvedEvent resolveEvent)
        {
            var type = Type.GetType(resolveEvent.Event.EventType);
            if (type != null && typeof(DomainEvent).IsAssignableFrom(type))
            {
                var domainEvent = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(resolveEvent.Event.Data),type);
                await bus.Publish(domainEvent);
                Console.WriteLine($"event published on bus");
            }
        }
    }
}
