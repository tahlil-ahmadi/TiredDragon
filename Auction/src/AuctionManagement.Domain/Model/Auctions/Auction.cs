using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AuctionManagement.Domain.Contracts;
using AuctionManagement.Domain.Framework;
using AuctionManagement.Domain.Model.Auctions.Exceptions;
using AuctionManagement.Domain.Model.Participants;

namespace AuctionManagement.Domain.Model.Auctions
{
    public partial class Auction : AggregateRoot<Guid>
    {
        public long SellerId { get; private set; }
        public long ProductId { get; private set; }
        public long StartingPrice { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public Bid WinningBid { get; private set; }
        protected Auction() { }
        public Auction(Participant seller, long productId, long startingPrice, DateTime endDateTime)
        {
            if (startingPrice <= 0) throw  new InvalidPriceException();
            if (IsPast(endDateTime)) throw new EndDateTimeIsPastException();

            Causes(new AuctionOpened(Guid.NewGuid(), seller.Id, productId, startingPrice, endDateTime));
        }
        public void PlaceBid(Bid bid)
        {
            if (this.StartingPrice >= bid.OfferAmount) throw new InvalidBidException();

            Causes(new BidPlaced(this.Id, bid.BidderId, bid.OfferAmount, bid.OfferDateTime));
        }
        private static bool IsPast(DateTime endDateTime)
        {
            return endDateTime <= DateTime.Now;
        }
    }
}
