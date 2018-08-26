using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EducaRank.MVC.ViewModels
{
    public class ConsultaEscolaVM
    {
        public List<SelectListItem> Bairros { get; set; }
        public string Bairro { get; set; }
        public string Escola { get; set; }
        public List<SelectListItem> TiposCiclos { get; set; }
        public string TipoCiclo { get; set; }
    }
}
