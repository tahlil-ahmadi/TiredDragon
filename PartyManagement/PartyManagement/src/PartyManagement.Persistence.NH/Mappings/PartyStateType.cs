using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using PartyManagement.Domain.Parties.States;

namespace PartyManagement.Persistence.NH.Mappings
{
    public class PartyStateType : ImmutableUserType<PartyState>
    {
        public override object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            var statusValue = (short)NHibernateUtil.Int16.NullSafeGet(rs, names[0],session);

            //TODO: use attributes to create states :D
            if (statusValue == 1)
                return new ConfirmedState();
            else if (statusValue == 0)
                return new InProgressState();
            else
                throw new NotImplementedException();
        }

        public override void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            var state = (PartyState)value;
            byte valueToSave;

            //TODO: use attributes to get numeric value from states :D
            if (state is InProgressState)
                valueToSave = 0;
            else if (state is ConfirmedState)
                valueToSave = 1;
            else
                throw new NotSupportedException();


            NHibernateUtil.String.NullSafeSet(cmd, valueToSave.ToString(), index, session);
        }

        public override SqlType[] SqlTypes => new[] { new SqlType(DbType.Byte) };
    }
}
