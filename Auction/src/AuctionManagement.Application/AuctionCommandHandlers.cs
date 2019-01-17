using System;
using AuctionManagement.Application.Contracts;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Domain.Model.Participants;

namespace AuctionManagement.Application
{
    public class AuctionCommandHandlers
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IParticipantRepository _participantRepository;
        public AuctionCommandHandlers(IAuctionRepository auctionRepository, 
                                      IParticipantRepository participantRepository)
        {
            _auctionRepository = auctionRepository;
            _participantRepository = participantRepository;
        }

        public void Handle(OpenAuctionCommand command)
        {
            var seller = _participantRepository.Get(command.SellerId);
            var auction = new Auction(seller, command.ProductId, command.StartingPrice, command.EndDateTime);
            _auctionRepository.Add(auction);
        }
        public void Handle(PlaceBidCommand command)
        {
            var auction = _auctionRepository.Get(command.AuctionId);
            var bid = new Bid
            {
                BidderId = command.BidderId,
                OfferAmount =command.BidAmount,
                OfferDateTime = DateTime.Now
            };
            auction.PlaceBid(bid);
            //update auction
        }
    }
}
