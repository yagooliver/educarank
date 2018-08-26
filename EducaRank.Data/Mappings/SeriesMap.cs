using FluentNHibernate.Mapping;
using EducaRank.Core.Entity;

namespace EducaRank.Data.Mappings
{
    public class SeriesMap : ClassMap<Series>
    {
        public SeriesMap()
        {
            Table("series");
            LazyLoad();
            Id(x => x.Id).CustomSqlType("serial").GeneratedBy.Identity().Column("id");
            Map(x => x.Id).Length(100).Column("idtipociclo").Not.Nullable();
            Map(x => x.Nome).Length(50).Column("nome").Not.Nullable();
            HasMany(x => x.DadosSeries);
            References(x => x.TipoCiclo, "idtipociclo");
            
        }
    }
}
