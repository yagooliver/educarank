using EducaRank.Application.Interface;
using EducaRank.Core.Entity;
using EducaRank.MVC.Utilitarios;
using EducaRank.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EducaRank.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEscolaAppService _escolaAppService;
        private readonly IBairrosAppService _bairroAppService;
        private readonly IDadosSeriesAppService _dadosSeriesAppService;
        private readonly IProvasSegmentosAppService _provasSegmentosAppService;
        private readonly ITipoCicloAppService _tipoCicloAppService;

        public HomeController(IEscolaAppService serviceEscola, IBairrosAppService serviceBairro, 
            IDadosSeriesAppService dadosSeriesAppService, IProvasSegmentosAppService provasSegmentosAppService,
            ITipoCicloAppService tipoCicloAppService)
        {
            _escolaAppService = serviceEscola;
            _bairroAppService = serviceBairro;
            _provasSegmentosAppService = provasSegmentosAppService;
            _dadosSeriesAppService = dadosSeriesAppService;
            _tipoCicloAppService = tipoCicloAppService;

        }
        // GET: Home
        public ActionResult Index()
        {
            //Core.Entity.Bairros bairros = new Core.Entity.Bairros()
            //{
            //    Idh = 1,
            //    IdhEducacao = 1,
            //    Nome = "Teste"
            //};
            //_bairroAppService.Create(bairros);
            return View();
        }

        public List<EscolaRank> Rankeia()
        {
            List<EscolaRank> escolasRankeadas = GeraListaDeEscolasVM();

            List<DadosSeries> dadosSeries = new List<DadosSeries>();
            List<ProvasSegmentos> provasSegmentos = new List<ProvasSegmentos>();

            //Começa a normalização dos objetos aqui.
            foreach (EscolaRank escola in escolasRankeadas)
            {
                foreach (DadosSeries dadosSerie in escola.DadosSeries)
                    dadosSeries.Add(dadosSerie);
                foreach (ProvasSegmentos provasSegmento in escola.ProvasSegmentos)
                    provasSegmentos.Add(provasSegmento);
            }

            foreach (EscolaRank escola in escolasRankeadas)
            {
                foreach (DadosSeries dadosSerie in escola.DadosSeries)
                    dadosSerie.TaxaAprovacao = Helpers.ValorNormalizado(dadosSerie.TaxaAprovacao, dadosSeries);

                //List das provas da escola
                List<double> listProvaBrasil = new List<double>();
                List<double> listIdeb = new List<double>();
                List<double> listSpaece = new List<double>();
                List<double> listReprovacao = new List<double>();

                foreach (ProvasSegmentos provaSegmento in escola.ProvasSegmentos)
                {
                    listProvaBrasil.Add(provaSegmento.ProvaBrasil);
                    listIdeb.Add(provaSegmento.Ideb);
                    listSpaece.Add(provaSegmento.Spaece);
                }

                foreach (DadosSeries dadosSerie in dadosSeries)
                    listReprovacao.Add(dadosSerie.TaxaAprovacao);


                for (int i = 0; i < escola.ProvasSegmentos.Count; i++)
                {
                    escola.ProvasSegmentos[i].ProvaBrasil = Helpers.ValorNormalizado(escola.ProvasSegmentos[i].ProvaBrasil, escola.ProvasSegmentos, "ProvaBrasil");
                    escola.ProvasSegmentos[i].Ideb = Helpers.ValorNormalizado(escola.ProvasSegmentos[i].Ideb, escola.ProvasSegmentos, "Ideb");
                    escola.ProvasSegmentos[i].Spaece = Helpers.ValorNormalizado(escola.ProvasSegmentos[i].Spaece, escola.ProvasSegmentos, "Spaece");
                    //acaba aqui a normalização 

                    escola.Nota = (((Helpers.Media(listProvaBrasil) + Helpers.Media(listIdeb) + Helpers.Media(listSpaece)) / 3) * 0.4) + (Helpers.Media(listReprovacao) * 0.6);
                }
            }

            return SortAlgorithm.QuickSortModificado(escolasRankeadas); 
        }

        private List<EscolaRank> GeraListaDeEscolasVM()
        {
            var escolas = _escolaAppService.GetAll();
            var provasSegmentos = _provasSegmentosAppService.GetAll();
            var dadosSeries = _dadosSeriesAppService.GetAll();

            List<EscolaRank> escolasRankVM = new List<EscolaRank>();

            foreach (Escola escola in escolas)
            {
                EscolaRank escolaRank = new EscolaRank();
                escolaRank.Escola = escola;

                foreach (ProvasSegmentos prova in provasSegmentos)
                {
                    if (prova.IdEscola == escola.Id)
                        escolaRank.ProvasSegmentos.Add(prova);
                }

                foreach (DadosSeries dadosSerie in dadosSeries)
                {
                    if (dadosSerie.IdEscola == escola.Id)
                        escolaRank.DadosSeries.Add(dadosSerie);
                }
                escolaRank.Id = escola.Id;
                escolasRankVM.Add(escolaRank);
            }


            return escolasRankVM;
        }

        public ActionResult MapaEscolas()
        {
            ConsultaEscolaVM consultaEscola = new ConsultaEscolaVM()
            {
                Bairros = Helpers.PreencheBairro(_bairroAppService),
                TiposCiclos = Helpers.PreencheTipoCiclo(_tipoCicloAppService)
            };

            return View(consultaEscola);
        }

        [HttpPost]
        public JsonResult ConsultaEscola(ConsultaEscolaVM escolaVM)
        {
            List<Escola> escola = new List<Escola>();

            if (!String.IsNullOrEmpty(escolaVM.TipoCiclo) && escolaVM.TipoCiclo != "0")
                 escola = _provasSegmentosAppService.FindByIdCiclo(Convert.ToInt32(escolaVM.TipoCiclo)).ToList();
            else
                escola = _escolaAppService.GetAll().ToList();

            if (!String.IsNullOrEmpty(escolaVM.Escola))
                escola = escola.Where(x => x.UnidadeEscolar.Contains(escolaVM.Escola.ToUpper())).ToList();

            if (!String.IsNullOrEmpty(escolaVM.Bairro) && escolaVM.Bairro != "0")
            {
                int bairro = Convert.ToInt32(escolaVM.Bairro);
                escola = escola.Where(x => x.Bairro.Id == bairro).ToList();
            }

            List<EscolaViewModel> escolas = (from item in escola
                                  select new EscolaViewModel()
                                  {
                                      Bairro = item.Bairro.Nome,
                                      Endereco = item.Endereco + "," + item.Bairro.Nome + ",Fortaleza,Ceará",
                                      Latitude = item.Latitude,
                                      Longitude = item.Longitude,
                                      UnidadeEscolar = item.UnidadeEscolar,
                                      CodInep = item.CodInep,
                                      idEscola = item.Id,
                                      IdhBairro = item.Bairro.Idh,
                                      IdhEducacaoBairro = item.Bairro.IdhEducacao,
                                      Nota = 0,
                                      Colocacao = 0,
                                      PossuiCreche = item.PossuiCreche,
                                      PossuiFundDois = item.PossuiFundDois,
                                      PossuiEducacaoInfantil = item.PossuiEducacaoInfantil,
                                      PossuiEja = item.PossuiEja,
                                      PossuiFundum = item.PossuiFundum,
                                      PossuiEF = item.PossuiEF,
                                      PossuiPreEscola = item.PossuiPreEscola

                                  }).ToList();
            List<EscolaRank> escolasRankeadas = Rankeia();
            //List<EscolaViewModel> escolas = listaDeEscolas.ToList();

            for (int i = 0; i < escolas.Count(); i++)
            {
                foreach(EscolaRank escolaRank in escolasRankeadas)
                {
                    if(escolas[i].idEscola == escolaRank.Escola.Id)
                    {
                        escolas[i].Nota = escolaRank.Nota;
                        escolas[i].Colocacao = escolaRank.Colocacao;
                        break;
                    }
                }

            }

            return Json(escolas.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DetalheEscola(int id, int colocacao, double nota)
        {
            Escola escola = new Escola();
            escola = _escolaAppService.GetById(id);
            EscolaViewModel escolaVM = new EscolaViewModel();

            escolaVM.Colocacao = colocacao;
            escolaVM.Nota = Math.Round(nota, 2);
            escolaVM.Bairro = escola.Bairro.Nome;
            escolaVM.Endereco = escola.Endereco + "," + escola.Bairro.Nome + ", Fortaleza, Ceará";
            escolaVM.UnidadeEscolar = escola.UnidadeEscolar;
            escolaVM.IdhBairro = escola.Bairro.Idh;
            escolaVM.IdhEducacaoBairro = escola.Bairro.IdhEducacao;
            escolaVM.PossuiCreche = escola.PossuiCreche;
            escolaVM.PossuiFundDois = escola.PossuiFundDois;
            escolaVM.PossuiEducacaoInfantil = escola.PossuiEducacaoInfantil;
            escolaVM.PossuiEja = escola.PossuiEja;
            escolaVM.PossuiFundum = escola.PossuiFundum;
            escolaVM.PossuiEF = escola.PossuiEF;
            escolaVM.PossuiPreEscola = escola.PossuiPreEscola;

            return View(escolaVM);
        }

    }
}