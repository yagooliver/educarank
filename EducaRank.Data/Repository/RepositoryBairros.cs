using EducaRank.Core.Entity;
using EducaRank.Core.Interface;
using EducaRank.Core.Interface.Repository;

namespace EducaRank.Data.Repository
{
    public class RepositoryBairros : RepositoryBase<Bairros>, IRepositoryBairros
    {
        private readonly IUnitOfWork _unitOfWork;
        public RepositoryBairros(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
