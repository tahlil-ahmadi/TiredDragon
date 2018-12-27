using System;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Auctions.Exceptions;
using AuctionManagement.Domain.Tests.Unit.Utility;
using FluentAssertions;
using Xunit;

namespace AuctionManagement.Domain.Tests.Unit
{
    public class AuctionTests
    {
        [Fact]
        public void should_create_auction_properly()
        {
            var builder = new AuctionTestBuilder();

            var auction = builder.Build();

            auction.Id.Should().NotBeEmpty();
            auction.StartingPrice.Should().Be(builder.StartingPrice);
            auction.EndDateTime.Should().Be(builder.EndDateTime);
            auction.SellerId.Should().Be(builder.SellerId);
            auction.ProductId.Should().Be(builder.ProductId);
            auction.WinningBid.Should().BeNull();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void should_throw_when_starting_price_is_invalid(long price)
        {
            Action constructor = ()=> new AuctionTestBuilder().WithStartingPrice(price).Build();

            constructor.Should().Throw<InvalidPriceException>();
        }

        [Fact]
        public void should_throw_when_end_date_time_is_past()
        {
            Action constructor = () => new AuctionTestBuilder().WithSomePastDate().Build();

            constructor.Should().Throw<EndDateTimeIsPastException>();
        }
    }
}
