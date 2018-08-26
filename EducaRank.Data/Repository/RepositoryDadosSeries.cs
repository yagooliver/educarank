using EducaRank.Core.Entity;
using EducaRank.Core.Interface;
using EducaRank.Core.Interface.Repository;

namespace EducaRank.Data.Repository
{
    public class RepositoryDadosSeries : RepositoryBase<DadosSeries>, IRepositoryDadosSeries
    {
        private readonly IUnitOfWork _unitOfWork;
        public RepositoryDadosSeries(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
