using System;
using System.Collections.Generic;
using System.Text;
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
            config.EnableInstallers();
            ConfigTransport(config);
            config.Conventions().DefiningEventsAs(a => typeof(DomainEvent).IsAssignableFrom(a));
            return Endpoint.Start(config).Result;
        }

        private static void ConfigTransport(EndpointConfiguration config)
        {
            var transport = config.UseTransport<RabbitMQTransport>();
            transport.ConnectionString("host=localhost");
            transport.UseConventionalRoutingTopology();
        }
    }
}
