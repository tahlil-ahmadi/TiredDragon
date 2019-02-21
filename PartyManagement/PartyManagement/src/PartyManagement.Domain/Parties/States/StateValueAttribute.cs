using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyManagement.Domain.Parties.States
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StateValueAttribute : Attribute
    {
        public long Value { get; set; }
        public StateValueAttribute(long value)
        {
            Value = value;
        }
    }
}
