using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace PartyManagement.Persistence.NH.Mappings
{
    public abstract class ImmutableUserType<T> : IUserType
    {
        public abstract object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner);
        public abstract void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session);

        public abstract SqlType[] SqlTypes { get; }

        public new bool Equals(object x, object y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.Equals(y);
        }

        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }

       

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            return DeepCopy(cached);
        }

        public object Disassemble(object value)
        {
            return DeepCopy(value);
        }

        public Type ReturnedType => typeof(T);
        public bool IsMutable => false;
    }

}
