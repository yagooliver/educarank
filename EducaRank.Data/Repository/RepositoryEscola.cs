using EducaRank.Core.Entity;
using EducaRank.Core.Interface;
using EducaRank.Core.Interface.Repository;

namespace EducaRank.Data.Repository
{
    public class RepositoryEscola : RepositoryBase<Escola>, IRepositoryEscola
    {
        private readonly IUnitOfWork _unitOfWork;
        public RepositoryEscola(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
