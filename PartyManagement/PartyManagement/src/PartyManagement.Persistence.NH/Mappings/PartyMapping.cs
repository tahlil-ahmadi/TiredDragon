using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PartyManagement.Domain.Parties;

namespace PartyManagement.Persistence.NH.Mappings
{
    public class PartyMapping : ClassMapping<Party>
    {
        public PartyMapping()
        {
            Table("Parties");
            Lazy(false);
            ComponentAsId(a=>a.Id, mapper =>
            {
                mapper.Property(a=>a.Id, a=> a.Column("Id"));
            });
            Property(a=>a.State, a=>a.Type<PartyStateType>());
            IdBag(a=>a.Phones, mapper =>
            {
                mapper.Table("Phones");
                mapper.Key(a=>a.Column("PartyId"));
                mapper.Access(Accessor.Field);
                mapper.Cascade(Cascade.All);
                mapper.Id(a =>
                {
                    a.Column("Id");
                    a.Generator(Generators.Identity);
                });
            }, relation => relation.Component(mapper =>
            {
                mapper.Property(a=>a.Area);
                mapper.Property(a=>a.Number);
            }));
        }
    }
}