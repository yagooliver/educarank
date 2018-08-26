using System.Collections.Generic;


namespace EducaRank.Core.Entity
{
    public class Bairros
    {
        public Bairros()
        {
            Escola = new List<Escola>();
        }
        public virtual int Id { get; set; }
        public virtual double Idh { get; set; }
        public virtual string Nome { get; set; }
        public virtual double IdhEducacao { get; set; }
        public virtual IList<Escola> Escola { get; set; }
    }
}
