using EducaRank.Application.Interface;
using EducaRank.Core.Entity;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Application.Application
{
    public class TipoEscolaAppService : AppServiceBase<TiposEscolas>, ITipoEscolaAppService
    { 
        private readonly IServiceTiposEscolas _serviceBase;
        public TipoEscolaAppService(IServiceTiposEscolas serviceBase) : base(serviceBase)
        {
            _serviceBase = serviceBase;
        }
    }
}
