using System.Collections.Generic;


namespace EducaRank.Core.Entity
{
    public class TiposEscolas
    {
        public TiposEscolas()
        {
            Escola = new List<Escola>();
        }
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Sigla { get; set; }
        public virtual IList<Escola> Escola { get; set; }
    }
}
