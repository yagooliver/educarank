using EducaRank.Core.Entity;
using EducaRank.Core.Interface;
using EducaRank.Core.Interface.Repository;

namespace EducaRank.Data.Repository
{
    public class RepositorySeries : RepositoryBase<Series>, IRepositorySeries
    {
        private readonly IUnitOfWork _unitOfWork;
        public RepositorySeries(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
