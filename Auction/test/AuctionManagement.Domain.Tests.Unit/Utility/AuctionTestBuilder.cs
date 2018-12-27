using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Model.Auctions;

namespace AuctionManagement.Domain.Tests.Unit.Utility
{
    public class AuctionTestBuilder
    {
        public long SellerId { get; private set; }
        public long ProductId { get; private set; }
        public long StartingPrice { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public AuctionTestBuilder()
        {
            this.SellerId = 1;
            this.ProductId = 20;
            this.StartingPrice = 20000;
            this.EndDateTime = DateTime.Now.AddDays(7);
        }
        public AuctionTestBuilder WithStartingPrice(long price)
        {
            this.StartingPrice = price;
            return this;
        }

        public AuctionTestBuilder WithSomePastDate()
        {
            this.EndDateTime = DateTime.Now.AddDays(-1);
            return this;
        }

        public Auction Build()
        {
            return new Auction(this.SellerId, this.ProductId , this.StartingPrice, this.EndDateTime);
        }
    }
}
