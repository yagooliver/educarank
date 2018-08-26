using EducaRank.Core.Entity;
using System.Collections.Generic;

namespace EducaRank.Core.Interface.Repository
{
    public interface IRepositoryProvasSegmentos : IRepositoryBase<ProvasSegmentos>
    {
        IEnumerable<Escola> FindByIdCiclo(int tipoCiclo);
    }
}
