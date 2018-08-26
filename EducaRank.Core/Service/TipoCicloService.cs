using EducaRank.Core.Entity;
using EducaRank.Core.Interface.Repository;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Core.Service
{
    public class TipoCicloService : ServiceBase<TipoCiclo>, IServiceTipoCiclo
    {
        private readonly IRepositoryTipoCiclo _repositoryBase;
        public TipoCicloService(IRepositoryTipoCiclo repositoryBase) : base(repositoryBase)
        {
            this._repositoryBase = repositoryBase;
        }
    }
}
