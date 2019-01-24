using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using PartyManagement.Domain.Parties;

namespace PartyManagement.Persistence.NH.Mappings
{
    public class IndividualPartyMapping : JoinedSubclassMapping<IndividualParty>
    {
        public IndividualPartyMapping()
        {
            Table("IndividualParties");
            Key(a=>a.Column("Id"));
            Lazy(false);
            Property(a=>a.Firstname);
            Property(a=>a.Lastname);
        }
    }
}
