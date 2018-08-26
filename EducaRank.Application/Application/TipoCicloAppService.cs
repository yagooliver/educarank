using EducaRank.Application.Interface;
using EducaRank.Core.Entity;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Application.Application
{
    public class TipoCicloAppService : AppServiceBase<TipoCiclo>, ITipoCicloAppService
    {
        private readonly IServiceTipoCiclo _serviceBase;
        public TipoCicloAppService(IServiceTipoCiclo serviceBase) : base(serviceBase)
        {
            _serviceBase = serviceBase;
        }
    }
}
