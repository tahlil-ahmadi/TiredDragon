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
        [Fact]
        public void should_set_bid_as_winning_bid_on_valid_bid()
        {
            var bid = new Builder().CreateNew<Bid>().With(a => a.OfferAmount = 1100).Build();

            this.Given(a => a.GivenIHaveAnAuctionWithStartingPrice(1000))
                .When(a => a.WhenIPlaceMyBid(bid))
                .Then(a => a.ThenMyBidShouldBeSetAsWinningBid(bid))
                .BDDfy();
        }
        

    }
}
