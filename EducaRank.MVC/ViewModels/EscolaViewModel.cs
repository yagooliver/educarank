namespace EducaRank.MVC.ViewModels
{
    public class EscolaViewModel
    {
        public string UnidadeEscolar { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string CodInep { get; set; }
        public int idEscola { get; set; }
        public string Bairro { get; set; }
        public double IdhBairro { get; set; }
        public double IdhEducacaoBairro { get; set; }
        public double Nota { get; set; }
        public double Colocacao { get; set; }
        public virtual bool? PossuiCreche { get; set; }
        public virtual bool? PossuiFundDois { get; set; }
        public virtual bool? PossuiEducacaoInfantil { get; set; }
        public virtual bool? PossuiEja { get; set; }
        public virtual bool? PossuiFundum { get; set; }
        public virtual bool? PossuiEF { get; set; }
        public virtual bool? PossuiPreEscola { get; set; }
    }
}
