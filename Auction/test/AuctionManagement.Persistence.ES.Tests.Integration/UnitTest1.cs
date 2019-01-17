using System;
using AuctionManagement.Domain.Model.Auctions;
using Xunit;

namespace AuctionManagement.Persistence.ES.Tests.Integration
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var repository = new AuctionRepository();

            #region Save
            //var auction = new Auction(1, 100, 2000000, DateTime.Now.AddDays(7));
            //auction.PlaceBid(new Bid { BidderId = 2, OfferAmount = 2010000 });
            //auction.PlaceBid(new Bid { BidderId = 3, OfferAmount = 2020000 });
            //repository.Add(auction);
            #endregion

            var id = Guid.Parse("947dfdd4-9417-4510-96fa-ebab4d81fae0");
            var auction = repository.Get(id);

        }
    }
}
