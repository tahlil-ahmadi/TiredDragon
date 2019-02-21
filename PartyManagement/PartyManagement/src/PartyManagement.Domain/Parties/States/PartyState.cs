using System;

namespace PartyManagement.Domain.Parties.States
{
    public abstract class PartyState
    {
        public virtual bool CanModify()
        {
            return false;
        }

        public virtual PartyState GotoConfirm()
        {
            throw new Exception();
        }
    }
}