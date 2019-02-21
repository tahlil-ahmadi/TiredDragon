using System;
using FluentAssertions;
using PartyManagement.Domain.Parties;
using PartyManagement.Domain.Parties.States;
using Xunit;

namespace PartyManagement.Domain.Tests.Unit
{
    public class PartyTests
    {
        [Fact]
        public void should_be_created_in_InProgress_state()
        {
            var party = new IndividualParty(new PartyId(1), "David", "X");

            party.State.Should().BeOfType<InProgressState>();
        }

        [Fact]
        public void should_transit_to_confirmed_state()
        {
            var party = new IndividualParty(new PartyId(1), "David", "X");

            party.Confirm();

            party.State.Should().BeOfType<ConfirmedState>();
        }
    }
}
