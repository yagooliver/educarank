using System.Collections.Generic;


namespace EducaRank.Core.Entity
{

    public class Escola
    {
        public Escola()
        {
            DadosSeries = new List<DadosSeries>();
        }
        public virtual int Id { get; set; }
        public virtual string UnidadeEscolar { get; set; }
        public virtual double Longitude { get; set; }
        public virtual double Latitude { get; set; }
        public virtual bool? PossuiCreche { get; set; }
        public virtual string Endereco { get; set; }
        public virtual bool? PossuiFundDois { get; set; }
        public virtual int IdTipoEscola { get; set; }
        public virtual string Cep { get; set; }
        public virtual string CodInep { get; set; }
        public virtual bool? PossuiEducacaoInfantil { get; set; }
        public virtual int CodPref { get; set; }
        public virtual bool? PossuiEja { get; set; }
        public virtual bool? PossuiFundum { get; set; }
        public virtual int IdBairros { get; set; }
        public virtual string Telefone { get; set; }
        public virtual bool? PossuiEF { get; set; }
        public virtual bool? PossuiPreEscola { get; set; }

        public virtual TiposEscolas TipoEscola { get; set; }
        public virtual Bairros Bairro { get; set; }

        public virtual IList<DadosSeries> DadosSeries { get; set; }
    }
}
