using System.Collections.Generic;

namespace EducaRank.Core.Entity
{
    public class TipoCiclo
    {
        public TipoCiclo()
        {
            ProvasSegmentos = new List<ProvasSegmentos>();
            Series = new List<Series>();
        }
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }

        public virtual IList<ProvasSegmentos> ProvasSegmentos { get; set; }
        public virtual IList<Series> Series { get; set; }
    }
}
