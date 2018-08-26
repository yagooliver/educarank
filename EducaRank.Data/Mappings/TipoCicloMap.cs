using EducaRank.Core.Entity;
using FluentNHibernate.Mapping;

namespace EducaRank.Data.Mappings
{
    public class TipoCicloMap : ClassMap<TipoCiclo>
    {
        public TipoCicloMap()
        {
            Table("tipociclo");
            LazyLoad();
            Id(x => x.Id).CustomSqlType("serial").GeneratedBy.Identity().Column("id");
            Map(x => x.Descricao).Length(100);
            HasMany(x => x.Series);
            HasMany(x => x.ProvasSegmentos);
        }
    }
}
