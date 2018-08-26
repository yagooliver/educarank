using EducaRank.Application.Application;
using EducaRank.Application.Interface;
using EducaRank.Core.Interface;
using EducaRank.Core.Interface.Repository;
using EducaRank.Core.Interface.Service;
using EducaRank.Core.Service;
using EducaRank.Data;
using EducaRank.Data.Repository;
using SimpleInjector;
using SimpleInjector.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducaRank.IOC
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            container.Register<IUnitOfWork, UnitOfWork>();

            container.RegisterOpenGeneric(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            container.Register<IRepositoryBairros, RepositoryBairros>();
            container.Register<IRepositoryDadosSeries, RepositoryDadosSeries>();
            container.Register<IRepositoryEscola, RepositoryEscola>();
            container.Register<IRepositoryProvasSegmentos, RepositoryProvasSegmentos>();
            container.Register<IRepositorySeries, RepositorySeries>();
            container.Register<IRepositoryTipoCiclo, RepositoryTipoCiclo>();
            container.Register<IRepositoryTipoEscola, RepositoryTiposEscolas>();

            container.RegisterOpenGeneric(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.Register<IServiceBairros, BairrosService>();
            container.Register<IServiceDadosSeries, DadosSeriesService>();
            container.Register<IServiceEscola, EscolaService>();
            container.Register<IServiceProvasSegmentos, ProvasSegmentosService>();
            container.Register<IServiceSeries, SeriesService>();
            container.Register<IServiceTipoCiclo, TipoCicloService>();
            container.Register<IServiceTiposEscolas, TiposEscolasService>();

            container.RegisterOpenGeneric(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            container.Register<IBairrosAppService, BairrosAppService>();
            container.Register<IDadosSeriesAppService, DadosSeriesAppService>();
            container.Register<IEscolaAppService, EscolaAppService>();
            container.Register<IProvasSegmentosAppService, ProvasSegmentosAppService>();
            container.Register<ISeriesAppService, SeriesAppService>();
            container.Register<ITipoCicloAppService, TipoCicloAppService>();
            container.Register<ITipoEscolaAppService, TipoEscolaAppService>();
            
            container.Verify();
            return container;
        }
    }
}