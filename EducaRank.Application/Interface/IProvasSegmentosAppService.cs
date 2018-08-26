using EducaRank.Core.Entity;
using System.Collections.Generic;

namespace EducaRank.Application.Interface
{
    public interface IProvasSegmentosAppService : IAppServiceBase<ProvasSegmentos>
    {
        IEnumerable<Escola> FindByIdCiclo(int tipoCiclo);
    }
}
