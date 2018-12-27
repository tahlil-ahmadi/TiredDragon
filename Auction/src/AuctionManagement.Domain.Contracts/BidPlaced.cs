using System;

namespace AuctionManagement.Domain.Contracts
{
    public class BidPlaced : DomainEvent
    {
        public Guid AuctionId { get; private set; }
        public long BidderId { get; private set; }
        public long OfferAmount { get; private set; }
        public DateTime OfferDateTime { get; private set; }
        public BidPlaced(Guid auctionId, long bidderId, long offerAmount, DateTime offerDateTime)
        {
            AuctionId = auctionId;
            BidderId = bidderId;
            OfferAmount = offerAmount;
            OfferDateTime = offerDateTime;
        }
    }
}