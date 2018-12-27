using System;

namespace AuctionManagement.Domain.Contracts
{
    public class AuctionOpened : DomainEvent
    {
        public Guid Id { get; private set; }
        public long SellerId { get; private set; }
        public long ProductId { get; private set; }
        public long StartingPrice { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public AuctionOpened(Guid id, long sellerId, long productId, long startingPrice, DateTime endDateTime)
        {
            Id = id;
            SellerId = sellerId;
            ProductId = productId;
            StartingPrice = startingPrice;
            EndDateTime = endDateTime;
        }
    }
}
