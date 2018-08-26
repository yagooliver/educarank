using EducaRank.Application.Interface;
using EducaRank.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EducaRank.MVC.Utilitarios
{
    public static class Helpers
    {
        public static List<SelectListItem> PreencheBairro(IBairrosAppService _bairrosService)
        {
            var listaBairros = new List<SelectListItem>();

            listaBairros.Add(new SelectListItem()
            {
                Text = "Selecione um bairro...",
                Value = "0",
                Selected = true
            });

            List<Core.Entity.Bairros> bairro = new List<Core.Entity.Bairros>();
            bairro = _bairrosService.GetAll().OrderBy(x => x.Nome).ToList();

            foreach (var b in bairro)
            {
                listaBairros.Add(new SelectListItem
                {
                    Text = b.Nome,
                    Value = b.Id.ToString()
                });
            }
            return listaBairros;
        }

        public static List<SelectListItem> PreencheTipoCiclo(ITipoCicloAppService _tipoCiclo)
        {
            var listaCiclo = new List<SelectListItem>();
            List<Core.Entity.TipoCiclo> ciclos = new List<Core.Entity.TipoCiclo>();
            ciclos = _tipoCiclo.GetAll().ToList();

            listaCiclo.Add(new SelectListItem()
            {
                Text = "Selecione um ciclo...",
                Value = "0",
                Selected = true
            });
            foreach (var ciclo in ciclos)
            {
                listaCiclo.Add(new SelectListItem()
                {
                    Text = ciclo.Descricao,
                    Value = ciclo.Id.ToString(),
                });
            }
            return listaCiclo;
        }

        public static double ValorNormalizado(double valor, List<DadosSeries> dadosSeries)
        {
            List<double> listTaxaAprovacao = new List<double>();
            foreach (DadosSeries dadosSerie in dadosSeries)
                listTaxaAprovacao.Add(dadosSerie.TaxaAprovacao);

            double maiorValor = 0;
            foreach (double item in listTaxaAprovacao)
                if (item > maiorValor)
                    maiorValor = item;

            return (valor / maiorValor) * 10;
        }

        public static double ValorNormalizado(double valor, IList<ProvasSegmentos> provasSegmentos, string nomeDaPropriedade)
        {
            try
            {

                List<double> listProvaBrasil = new List<double>();
                List<double> listIdeb = new List<double>();
                List<double> listSpaece = new List<double>();
                double maiorValor = 0;

                foreach (ProvasSegmentos provaSegmento in provasSegmentos)
                {
                    listProvaBrasil.Add(provaSegmento.ProvaBrasil);
                    listIdeb.Add(provaSegmento.Ideb);
                    listSpaece.Add(provaSegmento.Spaece);
                }
                switch (nomeDaPropriedade)
                {
                    case "ProvaBrasil":
                        foreach (ProvasSegmentos provasSegmento in provasSegmentos)
                            if (provasSegmento.ProvaBrasil > maiorValor)
                                maiorValor = provasSegmento.ProvaBrasil;
                        break;

                    case "Ideb":
                        foreach (ProvasSegmentos provasSegmento in provasSegmentos)
                            if (provasSegmento.Ideb > maiorValor)
                                maiorValor = provasSegmento.Ideb;
                        break;

                    case "Spaece":
                        foreach (ProvasSegmentos provasSegmento in provasSegmentos)
                            if (provasSegmento.Spaece > maiorValor)
                                maiorValor = provasSegmento.Spaece;
                        break;
                    default: throw new Exception("Parâmetro incorreto passado. Escolha uma prova pelas propriedades: Spaece, Ideb ou ProvaBrasil");
                }

                return (valor / maiorValor) * 10;
            }
            catch (Exception e)
            {
                //Criar TempDatas para mensagens amigáveis de erros na página layout
                return 0;
            }
        }

        public static double Media(List<double> valores)
        {
            double media = 0;
            foreach (double valor in valores)
                media += valor;

            return media / valores.Count;
        }
    }
}
