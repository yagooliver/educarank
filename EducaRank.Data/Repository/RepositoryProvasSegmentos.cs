using System;
using System.Collections.Generic;
using EducaRank.Core.Entity;
using EducaRank.Core.Interface;
using EducaRank.Core.Interface.Repository;
using System.Linq;

namespace EducaRank.Data.Repository
{
    public class RepositoryProvasSegmentos : RepositoryBase<ProvasSegmentos>, IRepositoryProvasSegmentos
    {
        private readonly IUnitOfWork _unitOfWork;
        public RepositoryProvasSegmentos(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Escola> FindByIdCiclo(int tipoCiclo)
        {
            IEnumerable<Escola> escolas = FindBy(x => x.IdTipoCiclo == tipoCiclo).Select(x => x.Escola).Distinct();
            return escolas;
        }
    }
}
