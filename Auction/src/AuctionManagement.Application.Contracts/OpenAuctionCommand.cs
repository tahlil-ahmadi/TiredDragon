using System;

namespace AuctionManagement.Application.Contracts
{
    public class OpenAuctionCommand
    {
        public long ProductId { get; set; }
        public long StartingPrice { get; set; }
        public DateTime EndDateTime { get; set; }
        public long SellerId { get; set; }
    }
}