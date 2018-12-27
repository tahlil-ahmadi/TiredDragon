using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Contracts;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;

namespace Syncs.QueryModelSync
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync().Wait();

            var credential = new UserCredentials("admin", "changeit");
            //connection.SubscribeToAllAsync(false, EventAppeared, SubscriptionDropped, credential).Wait();
            var settings = new CatchUpSubscriptionSettings(4096, 4096, false, false);
            //connection.SubscribeToAllFrom(Position.Start, settings, CatchUpEventAppeared, CatchUpSubscriptionDropped);
            connection.SubscribeToStreamFrom("Auction-185f0b86-8c1e-442c-8767-cdbf480b321f",0, settings, CatchUpEventAppeared, CatchUpSubscriptionDropped);

            Console.WriteLine("Subscription started !");
            Console.ReadLine();
        }

        private static void CatchUpSubscriptionDropped(EventStoreCatchUpSubscription obj)
        {
            Console.WriteLine("Subscription Dropped !");
        }
        private static Task CatchUpEventAppeared(EventStoreCatchUpSubscription arg1, ResolvedEvent resolvedEvent)
        {
            var type = Type.GetType(resolvedEvent.Event.EventType);
            if (type != null && typeof(DomainEvent).IsAssignableFrom(type))
            {
                var json = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
                Console.WriteLine(json);
            }
            return Task.CompletedTask;
        }

        private static Task EventAppeared(EventStoreSubscription arg1, ResolvedEvent resolvedEvent)
        {
            var type = Type.GetType(resolvedEvent.Event.EventType);
            if (type != null && typeof(DomainEvent).IsAssignableFrom(type))
            {
                var json = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
                Console.WriteLine(json);
            }
            return Task.CompletedTask;
        }
        private static void SubscriptionDropped(EventStoreSubscription arg1, SubscriptionDropReason arg2, Exception arg3)
        {
            Console.WriteLine("Subscription Dropped !");
        }

       
    }
}
