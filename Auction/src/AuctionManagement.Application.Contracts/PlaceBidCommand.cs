using System;

namespace AuctionManagement.Application.Contracts
{
    public class PlaceBidCommand
    {
        public long BidderId { get; set; }
        public Guid AuctionId { get; set; }
        public long BidAmount { get; set; }
    }
}
