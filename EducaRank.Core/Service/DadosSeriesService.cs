using EducaRank.Core.Entity;
using EducaRank.Core.Interface;
using EducaRank.Core.Interface.Repository;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Core.Service
{
    public class DadosSeriesService : ServiceBase<DadosSeries>,IServiceDadosSeries
    {
        private readonly IRepositoryDadosSeries _repositoryBase;
        public DadosSeriesService(IUnitOfWork unitOfWork, IRepositoryDadosSeries repositoryBase) : base(repositoryBase)
        {
            this._repositoryBase = repositoryBase;
        }
    }
}
