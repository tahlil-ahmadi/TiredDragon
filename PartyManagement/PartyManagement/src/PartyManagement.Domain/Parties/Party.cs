using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyManagement.Domain.Parties
{
    public abstract class Party
    {
        public PartyId Id { get; private set; }

        private IList<Phone> _phones;
        public IReadOnlyCollection<Phone> Phones => new ReadOnlyCollection<Phone>(this._phones);
        protected Party() { }
        protected Party(PartyId id)
        {
            this.Id = id;
            this._phones = new List<Phone>();
        }
        public void AssignPhones(List<Phone> phones)
        {
            //TODO: move to an generic extension method 
            var added = phones.Except(this._phones).ToList();
            var removed = this._phones.Except(phones).ToList();

            added.ForEach(a=> this._phones.Add(a));
            removed.ForEach(a=> this._phones.Remove(a));
        }
    }
}
