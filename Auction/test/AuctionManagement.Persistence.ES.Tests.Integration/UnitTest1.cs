using System;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Participants;
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
            var auction = new Auction(new Participant(100,"Ali"),1, 2000000, DateTime.Now.AddDays(7));
            //auction.PlaceBid(new Bid { BidderId = 2, OfferAmount = 2010000 });
            //auction.PlaceBid(new Bid { BidderId = 3, OfferAmount = 2020000 });
            repository.Add(auction);
            #endregion


        }
    }
}
