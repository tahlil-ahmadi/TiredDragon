using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Contracts;
using NServiceBus;

namespace NotificationManagement.Gateways.Nsb
{
    public class AuctionHandlers : IHandleMessages<BidPlaced>
    {
        public Task Handle(BidPlaced message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Bid placed handled ! Amount : {message.OfferAmount}");
            return Task.CompletedTask;
        }
    }
}
