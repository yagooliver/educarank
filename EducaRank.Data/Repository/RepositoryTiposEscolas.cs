using EducaRank.Core.Entity;
using EducaRank.Core.Interface;
using EducaRank.Core.Interface.Repository;

namespace EducaRank.Data.Repository
{
    public class RepositoryTiposEscolas : RepositoryBase<TiposEscolas>, IRepositoryTipoEscola
    {
        private readonly IUnitOfWork _unitOfWork;
        public RepositoryTiposEscolas(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
