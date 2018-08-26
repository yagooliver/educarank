namespace EducaRank.Core.Entity
{

    public class DadosSeries
    {
        public virtual int Id { get; set; }        
        public virtual int Ano { get; set; }
        public virtual int IdEscola { get; set; }
        public virtual double TaxaAprovacao { get; set; }
        public virtual int IdSerie { get; set; }

        public virtual Escola Escola { get; set; }
        public virtual Series Series { get; set; }
    }
}
