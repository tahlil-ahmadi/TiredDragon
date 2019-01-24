using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyManagement.Domain.Parties
{
    public class Phone
    {
        public string Area { get; private set; }
        public string Number { get; private set; }
        protected Phone() { }
        public Phone(string area, string number)
        {
            Area = area;
            Number = number;
        }

        protected bool Equals(Phone other)
        {
            return string.Equals(Area, other.Area) && string.Equals(Number, other.Number);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Phone) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Area != null ? Area.GetHashCode() : 0) * 397) ^ (Number != null ? Number.GetHashCode() : 0);
            }
        }
    }
}
