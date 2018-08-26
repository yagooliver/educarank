using EducaRank.Core.Entity;
using EducaRank.Core.Interface;
using EducaRank.Core.Interface.Repository;

namespace EducaRank.Data.Repository
{
    public class RepositoryTipoCiclo : RepositoryBase<TipoCiclo>, IRepositoryTipoCiclo

    {
        private readonly IUnitOfWork _unitOfWork;
        public RepositoryTipoCiclo(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
