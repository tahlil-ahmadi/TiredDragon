using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Auctions.Exceptions;
using AuctionManagement.Domain.Tests.Unit.Utility;
using FizzWare.NBuilder;
using FluentAssertions;
using TestStack.BDDfy;
using Xunit;

namespace AuctionManagement.Domain.Tests.Unit
{
    public partial class Auction_FirstBid_Tests
    {
        private AuctionTestBuilder _builder;
        private Auction _auction;
        public Auction_FirstBid_Tests()
        {
            this._builder = new AuctionTestBuilder();
        }

        private void GivenIHaveAnAuctionWithStartingPrice(int startingPrice)
        {
            _auction = _builder.WithStartingPrice(startingPrice).Build();
        }

        private void WhenIPlaceMyBid(Bid bid)
        {
            this._auction.PlaceBid(bid);
        }
        private void ThenMyBidShouldBeSetAsWinningBid(Bid bid)
        {
            this._auction.WinningBid.Should().BeEquivalentTo(bid);
        }
        
    }
}
