using EducaRank.Core.Entity;
using EducaRank.Core.Interface.Repository;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Core.Service
{
    public class TiposEscolasService : ServiceBase<TiposEscolas>, IServiceTiposEscolas
    {
        private readonly IRepositoryTipoEscola _repositoryBase;
        public TiposEscolasService(IRepositoryTipoEscola repositoryBase) : base(repositoryBase)
        {
            this._repositoryBase = repositoryBase;
        }
    }
}
