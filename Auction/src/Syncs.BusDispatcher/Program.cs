using System;
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
        private static IEndpointInstance _bus;
        static void Main(string[] args)
        {
            _bus = EndpointConfig.Config();

            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync().Wait();
            var credential = new UserCredentials("admin", "changeit");
            connection.SubscribeToAllAsync(false, EventAppeared, SubscriptionDropped, credential).Wait();

            Console.ReadLine();
        }
        private static async Task EventAppeared(EventStoreSubscription arg1, ResolvedEvent resolvedEvent)
        {
            var type = Type.GetType(resolvedEvent.Event.EventType);
            if (type != null && typeof(DomainEvent).IsAssignableFrom(type))
            {
                var json = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
                var instance = JsonConvert.DeserializeObject(json, type);
                await PublishOnBus(instance);
            }
        }
        private static async Task PublishOnBus(object message)
        {
            await _bus.Publish(message);
            Console.WriteLine("published on bus !");
        }
        private static void SubscriptionDropped(EventStoreSubscription arg1, SubscriptionDropReason arg2, Exception arg3)
        {
            Console.WriteLine("Subscription Dropped !");
        }
    }
}
