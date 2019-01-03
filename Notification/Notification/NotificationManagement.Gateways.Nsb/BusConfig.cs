using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Contracts;
using NServiceBus;

namespace NotificationManagement.Gateways.Nsb
{
    public static class BusConfig
    {
        public static IEndpointInstance Config()
        {
            var config = new EndpointConfiguration("NotificationManagement");
            config.SendFailedMessagesTo("NotificationManagement.Error");
            var transport = config.UseTransport<MsmqTransport>();
            transport.Routing().RegisterPublisher(typeof(BidPlaced),"AuctionManagement.Dispatcher");
            config.UsePersistence<InMemoryPersistence>();
            config.EnableInstallers();
            config.Conventions().DefiningEventsAs(a => typeof(DomainEvent).IsAssignableFrom(a));

            return Endpoint.Start(config).Result;
        }
    }
}
