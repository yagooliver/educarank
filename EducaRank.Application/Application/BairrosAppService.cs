using EducaRank.Application.Interface;
using EducaRank.Core.Entity;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Application.Application
{
    public class BairrosAppService : AppServiceBase<Bairros>, IBairrosAppService
    {
        private readonly IServiceBairros _serviceBase;
        public BairrosAppService(IServiceBairros serviceBase) : base(serviceBase)
        {
            _serviceBase = serviceBase;
        }
    }
}
