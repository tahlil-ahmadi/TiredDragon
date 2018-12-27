using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionManagement.Domain.Model.Auctions
{
    public class Bid
    {
        public long BidderId { get; set; }
        public long OfferAmount { get; set; }
        public DateTime OfferDateTime { get; set; } = DateTime.Now;

    }
}
