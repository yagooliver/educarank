using EducaRank.Core.Entity;
using System.Collections.Generic;

namespace EducaRank.Core.Interface.Service
{
    public interface IServiceProvasSegmentos : IServiceBase<ProvasSegmentos>
    {
        IEnumerable<Escola> FindByIdCiclo(int tipoCiclo);
    }
}
