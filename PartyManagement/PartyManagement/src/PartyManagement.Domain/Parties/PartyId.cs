using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyManagement.Domain.Parties
{
    public class PartyId
    {
        public long Id { get; private set; }
        protected PartyId(){}
        public PartyId(long id)
        {
            Id = id;
        }
        protected bool Equals(PartyId other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PartyId) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
