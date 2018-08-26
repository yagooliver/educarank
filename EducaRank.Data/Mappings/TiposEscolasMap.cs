using FluentNHibernate.Mapping;
using EducaRank.Core.Entity;

namespace EducaRank.Data.Mappings
{
    public class TiposescolasMap : ClassMap<TiposEscolas>
    {
        public TiposescolasMap()
        {
            Table("tiposescolas");
            LazyLoad();
            Id(x => x.Id).CustomSqlType("serial").GeneratedBy.Identity().Column("id");
            Map(x => x.Nome).Length(255).Column("nome").Not.Nullable();
            Map(x => x.Sigla).Length(3).Column("sigla").Not.Nullable();
            HasMany(x => x.Escola);
        }
    }
}
