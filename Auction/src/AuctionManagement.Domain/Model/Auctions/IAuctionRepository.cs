using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionManagement.Domain.Model.Auctions
{
    public interface IAuctionRepository
    {
        Auction Get(Guid id);
        void Add(Auction auction);
    }
}
