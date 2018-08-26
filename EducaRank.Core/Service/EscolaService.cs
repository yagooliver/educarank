using EducaRank.Core.Entity;
using EducaRank.Core.Interface;
using EducaRank.Core.Interface.Repository;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Core.Service
{
    public class EscolaService : ServiceBase<Escola>, IServiceEscola
    {
        private readonly IRepositoryEscola _repositoryBase;
        public EscolaService(IUnitOfWork unitOfWork, IRepositoryEscola repositoryBase) : base(repositoryBase)
        {
            this._repositoryBase = repositoryBase;
        }
    }
}
