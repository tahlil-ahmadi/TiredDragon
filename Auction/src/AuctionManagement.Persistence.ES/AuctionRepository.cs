using System;
using System.Linq;
using System.Net;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Persistence.ES.Tools;
using EventStore.ClientAPI;

namespace AuctionManagement.Persistence.ES
{
    public class AuctionRepository : EventSourcedRepository<Auction,Guid>, IAuctionRepository
    {
     
    }
}
