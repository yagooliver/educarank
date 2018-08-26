using EducaRank.Core.Entity;
using EducaRank.Core.Interface.Repository;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Core.Service
{
    public class SeriesService : ServiceBase<Series>, IServiceSeries
    {
        private readonly IRepositorySeries _repositoryBase;
        public SeriesService(IRepositorySeries repositoryBase) : base(repositoryBase)
        {
            this._repositoryBase = repositoryBase;
        }
    }
}
