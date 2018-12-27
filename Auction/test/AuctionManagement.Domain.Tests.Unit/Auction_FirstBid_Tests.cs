using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Auctions.Exceptions;
using AuctionManagement.Domain.Tests.Unit.Utility;
using FizzWare.NBuilder;
using FluentAssertions;
using Xunit;

namespace AuctionManagement.Domain.Tests.Unit
{
    public class Auction_FirstBid_Tests
    {
        private AuctionTestBuilder _builder;
        public Auction_FirstBid_Tests()
        {
            this._builder = new AuctionTestBuilder();
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(900)]
        public void should_throw_on_invalid_offer_amount(long amount)
        {
            var auction = _builder.WithStartingPrice(1000).Build();
            var bid = new Builder().CreateNew<Bid>().With(a => a.OfferAmount = amount).Build();

            Action placeBid = () => auction.PlaceBid(bid);

            placeBid.Should().Throw<InvalidBidException>();
        }

        [Fact]
        public void should_set_bid_as_winning_bid_on_valid_bid()
        {
            var auction = _builder.WithStartingPrice(1000).Build();
            var bid = new Builder().CreateNew<Bid>().With(a => a.OfferAmount = 1100).Build();

            auction.PlaceBid(bid);

            auction.WinningBid.Should().Be(bid);
        }
    }
}
