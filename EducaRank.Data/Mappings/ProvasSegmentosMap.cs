using EducaRank.Core.Entity;
using FluentNHibernate.Mapping;

namespace EducaRank.Data.Mappings
{
    public class ProvasSegmentosMap : ClassMap<ProvasSegmentos>
    {
        public ProvasSegmentosMap()
        {
            Table("provassegmentos");
            LazyLoad();
            Id(x => x.IdRegistro).CustomSqlType("serial").GeneratedBy.Identity().Column("id");
            Map(x => x.IdTipoCiclo, "idtipociclo");
            Map(x => x.IdEscola, "idescola");
            Map(x => x.Ano, "ano");
            Map(x => x.ProvaBrasil, "provabrasil").CustomSqlType("numeric(5,2)");
            Map(x => x.Ideb, "ideb").CustomSqlType("numeric(5,2)");
            Map(x => x.Spaece, "spaece").CustomSqlType("numeric(5,2)");
            References(x => x.TipoCiclo, "idtipociclo");
            References(x => x.Escola, "idescola");
        }
    }
}
