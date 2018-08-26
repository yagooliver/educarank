using FluentNHibernate.Mapping;
using EducaRank.Core.Entity;

namespace EducaRank.Data.Mappings
{


    public class BairrosMap : ClassMap<Bairros>
    {
        public BairrosMap()
        {
            Table("bairros");
            LazyLoad();
            Id(x => x.Id).CustomSqlType("serial").GeneratedBy.Identity().Column("id");
            Map(x => x.Idh).Column("idh").CustomSqlType("numeric(5,4)").Not.Nullable();
            Map(x => x.Nome).Length(100).Column("nome").Not.Nullable();
            Map(x => x.IdhEducacao).CustomSqlType("numeric(5,4)").Column("idheducacao").Not.Nullable();
            HasMany(x => x.Escola);
        }
    }
}
