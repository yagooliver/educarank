using System;
using System.Collections.Generic;
using EducaRank.Core.Entity;
using EducaRank.Core.Interface.Repository;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Core.Service
{
    public class ProvasSegmentosService : ServiceBase<ProvasSegmentos>, IServiceProvasSegmentos
    {
        private readonly IRepositoryProvasSegmentos _repositoryBase;
        public ProvasSegmentosService(IRepositoryProvasSegmentos repositoryBase) : base(repositoryBase)
        {
            this._repositoryBase = repositoryBase;
        }

        public IEnumerable<Escola> FindByIdCiclo(int tipoCiclo)
        {
            return _repositoryBase.FindByIdCiclo(tipoCiclo);
        }
    }
}
