using AutoMapper;
using EducaRank.Core.Entity;
using EducaRank.MVC.ViewModels;

namespace EducaRank.MVC.AutoMappers
{
    public class DomainToViewModelMappingsProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }
        protected override void Configure()
        {
            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Bairros, BairrosViewModel>();
                cfg.CreateMap<DadosSeries, DadosSeriesViewModel>();
                cfg.CreateMap<Escola, EscolaViewModel>();
                cfg.CreateMap<Series, SeriesViewModel>();
                cfg.CreateMap<TiposEscolas, TiposEscolasViewModel>();
            });

        }
    }
}
