using EducaRank.Application.Interface;
using EducaRank.Core.Entity;
using EducaRank.Core.Interface.Service;

namespace EducaRank.Application.Application
{
    public class SeriesAppService : AppServiceBase<Series>, ISeriesAppService
    {
        private readonly IServiceSeries _serviceBase;
        public SeriesAppService(IServiceSeries serviceBase) : base(serviceBase)
        {
            _serviceBase = serviceBase;
        }
    }
}
