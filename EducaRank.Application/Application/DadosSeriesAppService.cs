using EducaRank.Application.Interface;
using EducaRank.Core.Entity;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Application.Application
{
    public class DadosSeriesAppService : AppServiceBase<DadosSeries>, IDadosSeriesAppService
    {
        private readonly IServiceDadosSeries _serviceBase;
        public DadosSeriesAppService(IServiceDadosSeries serviceBase) : base(serviceBase)
        {
            _serviceBase = serviceBase;
        }
    }
}
