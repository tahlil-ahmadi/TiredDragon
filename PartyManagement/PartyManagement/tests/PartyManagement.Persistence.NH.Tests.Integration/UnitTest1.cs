using System;
using System.Collections.Generic;
using PartyManagement.Domain.Parties;
using PartyManagement.Persistence.NH.Mappings;
using Xunit;

namespace PartyManagement.Persistence.NH.Tests.Integration
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            var connectionString = @"Data source=CLASS1\MSSQLSERVER1; Initial Catalog=PartyManagementDB;User Id=sa;Password=123";
            var factory = SessionFactoryBuilder.Create(typeof(PartyMapping).Assembly, connectionString);
            var session = factory.OpenSession();

            session.BeginTransaction();

            var party = session.Get<IndividualParty>(new PartyId(1));
            var phones = new List<Phone>()
            {
                new Phone("021","11"),
                new Phone("021","44"),
            };
            party.AssignPhones(phones);

            session.Save(party);
            session.Transaction.Commit();
        }
    }
}
