using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyManagement.Domain.Parties
{
    public class IndividualParty : Party
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        protected IndividualParty() { }
        public IndividualParty(PartyId id,string firstname, string lastname) : base(id)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
       
        
    }
}
