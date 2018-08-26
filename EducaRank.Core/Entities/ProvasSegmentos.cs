namespace EducaRank.Core.Entity
{
    public class ProvasSegmentos
    {
        public virtual int IdRegistro { get; set; }
        public virtual int IdEscola { get; set; }
        public virtual int IdTipoCiclo { get; set; }
        public virtual int Ano { get; set; }
        public virtual double Ideb { get; set; }
        public virtual double ProvaBrasil { get; set; }
        public virtual double Spaece { get; set; }
        public virtual Escola Escola { get; set; }
        public virtual TipoCiclo TipoCiclo { get; set; }
    }
}
