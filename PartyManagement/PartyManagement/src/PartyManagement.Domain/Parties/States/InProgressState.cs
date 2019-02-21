using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyManagement.Domain.Parties.States
{
    public class InProgressState : PartyState
    {
        public override bool CanModify() => true;
        public override PartyState GotoConfirm() => new ConfirmedState();
    }
}
