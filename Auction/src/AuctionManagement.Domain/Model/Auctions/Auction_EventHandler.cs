using AuctionManagement.Domain.Contracts;

namespace AuctionManagement.Domain.Model.Auctions
{
    public partial class Auction
    {
        public void Causes(DomainEvent @event)
        {
            this.Apply(@event);
            this.Publish(@event);
        }
        public override void Apply(DomainEvent @event)
        {
            this.When((dynamic)@event);
        }
        private void When(AuctionOpened @event)
        {
            this.Id = @event.Id;
            SellerId = @event.SellerId;
            ProductId = @event.ProductId;
            StartingPrice = @event.StartingPrice;
            EndDateTime = @event.EndDateTime;
        }
        private void When(BidPlaced @event)
        {
            this.WinningBid = new Bid()
            {
                BidderId = @event.BidderId,
                OfferDateTime = @event.OfferDateTime,
                OfferAmount = @event.OfferAmount
            };
        }
    }
}