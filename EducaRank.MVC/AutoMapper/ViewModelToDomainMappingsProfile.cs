using AutoMapper;
using EducaRank.Core.Entity;
using EducaRank.MVC.ViewModels;

namespace EducaRank.MVC.AutoMappers
{
    public class ViewModelToDomainMappingsProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }
        protected override void Configure()
        {
            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BairrosViewModel,Bairros>();
                cfg.CreateMap<DadosSeriesViewModel, DadosSeries>();
                cfg.CreateMap<EscolaViewModel, Escola>();
                cfg.CreateMap<SeriesViewModel, Series>();
                cfg.CreateMap<TiposEscolasViewModel, TiposEscolas>();
            });
        }
    }
}
