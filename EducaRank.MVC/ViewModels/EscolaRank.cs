using EducaRank.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducaRank.MVC.ViewModels
{
    public class EscolaRank
    {
        public EscolaRank()
        {
            ProvasSegmentos = new List<ProvasSegmentos>();
            DadosSeries = new List<DadosSeries>();
        }
        public int Id { get; set; }
        public int Colocacao { get; set; }
        public double Nota { get; set; }
        public Escola Escola { get; set; }
        public IList<DadosSeries> DadosSeries { get; set; }
        public IList<ProvasSegmentos> ProvasSegmentos { get; set; }
    }
}