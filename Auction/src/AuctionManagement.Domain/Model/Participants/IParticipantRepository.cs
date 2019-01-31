using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionManagement.Domain.Model.Participants
{
    public interface IParticipantRepository
    {
        Participant Get(long id);
    }
}
