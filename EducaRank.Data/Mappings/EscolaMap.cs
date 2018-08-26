using FluentNHibernate.Mapping;
using EducaRank.Core.Entity;

namespace EducaRank.Data.Mappings
{


    public class EscolaMap : ClassMap<Escola>
    {
        public EscolaMap()
        {
            Table("escola");
            LazyLoad();
            Id(x => x.Id).CustomSqlType("serial").GeneratedBy.Identity().Column("id");
            Map(x => x.UnidadeEscolar).Length(255).Column("unidadeescolar");
            Map(x => x.PossuiCreche).Column("possuicreche");
            Map(x => x.Endereco).Length(255).Column("endereco");
            Map(x => x.PossuiFundDois).Column("possuifunddois");
            Map(x => x.IdTipoEscola).Column("idtipoescola").Not.Nullable();
            Map(x => x.Cep).Length(9).Column("cep");
            Map(x => x.Latitude, "latitude").CustomSqlType("numeric(9,7");
            Map(x => x.Longitude, "longitude").CustomSqlType("numeric(10,7)");
            Map(x => x.CodInep).Length(8).Column("codinep");
            Map(x => x.PossuiEducacaoInfantil).Column("possuieducacaoinfantil");
            Map(x => x.CodPref).Column("codpref").Not.Nullable();
            Map(x => x.PossuiEja).Column("possuieja");
            Map(x => x.PossuiFundum).Column("possuifundum");
            Map(x => x.IdBairros).Column("idbairros").Not.Nullable();
            References(x => x.Bairro, "idbairros");
            References(x => x.TipoEscola, "idtipoescola");
            Map(x => x.Telefone).Length(14).Column("telefone");
            Map(x => x.PossuiEF).Column("possuief");
            Map(x => x.PossuiPreEscola).Column("possuipreescola");
            HasMany(x => x.DadosSeries);
        }
    }
}
