using System.Collections.Generic;


namespace EducaRank.Core.Entity
{

    public class Series {
        public Series() {
            DadosSeries = new List<DadosSeries>();
        }
        public virtual int Id { get; set; }
        public virtual int IdTipociclo { get; set; }
        public virtual string Nome { get; set; }
        public virtual IList<DadosSeries> DadosSeries { get; set; }
        public virtual TipoCiclo TipoCiclo { get; set; }
    }
}
