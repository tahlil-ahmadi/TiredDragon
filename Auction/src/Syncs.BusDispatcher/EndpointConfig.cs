using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Contracts;
using NServiceBus;

namespace Syncs.BusDispatcher
{
    public static class EndpointConfig
    {
        public static IEndpointInstance Config()
        {
            var config = new EndpointConfiguration("AuctionManagement.Dispatcher");
            config.SendFailedMessagesTo("AuctionManagement.Dispatcher.Error");
            config.UseTransport<MsmqTransport>();
            config.UsePersistence<InMemoryPersistence>();
            config.EnableInstallers();
            config.Conventions().DefiningEventsAs(a => typeof(DomainEvent).IsAssignableFrom(a));

            return Endpoint.Start(config).Result;
        }
    }
}
