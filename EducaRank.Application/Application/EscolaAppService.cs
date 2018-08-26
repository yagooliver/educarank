using EducaRank.Application.Interface;
using EducaRank.Core.Entity;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Application.Application
{
    public class EscolaAppService : AppServiceBase<Escola>, IEscolaAppService
    {
        private readonly IServiceEscola _serviceBase;
        public EscolaAppService(IServiceEscola serviceBase) : base(serviceBase)
        {
            _serviceBase = serviceBase;
        }
    }
}
