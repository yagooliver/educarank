using FluentNHibernate.Mapping;
using EducaRank.Core.Entity;

namespace EducaRank.Data.Mappings
{
    public class DadosSeriesMap : ClassMap<DadosSeries>
    {
        public DadosSeriesMap()
        {
            Table("dadosseries");
            LazyLoad();
            Id(x => x.Id).CustomSqlType("serial").GeneratedBy.Identity().Column("id");
            Map(x => x.Ano).Column("ano").Not.Nullable();
            Map(x => x.IdEscola).Column("idescola").Not.Nullable();
            Map(x => x.TaxaAprovacao).Column("taxaaprovacao").CustomSqlType("numeric(5,2)").Not.Nullable();
            Map(x => x.IdSerie).Column("idserie").Not.Nullable();
            References(x => x.Series, "idserie");
            References(x => x.Escola, "idescola");
        }
    }
}
