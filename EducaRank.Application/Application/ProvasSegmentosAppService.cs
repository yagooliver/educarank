using System;
using System.Collections.Generic;
using EducaRank.Application.Interface;
using EducaRank.Core.Entity;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Application.Application
{
    public class ProvasSegmentosAppService : AppServiceBase<ProvasSegmentos>, IProvasSegmentosAppService
    {
        private readonly IServiceProvasSegmentos _serviceBase;
        public ProvasSegmentosAppService(IServiceProvasSegmentos serviceBase) : base(serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public IEnumerable<Escola> FindByIdCiclo(int tipoCiclo)
        {
            return _serviceBase.FindByIdCiclo(tipoCiclo);
        }
    }
}
