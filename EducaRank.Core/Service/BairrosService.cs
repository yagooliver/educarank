using EducaRank.Core.Entity;
using EducaRank.Core.Interface.Repository;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Core.Service
{
    public class BairrosService : ServiceBase<Bairros>, IServiceBairros
    {
        private readonly IRepositoryBairros _repositoryBase;
        public BairrosService(IRepositoryBairros repositoryBase) : base(repositoryBase)
        {
            this._repositoryBase = repositoryBase;
        }
    }
}
