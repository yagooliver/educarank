using AutoMapper;

namespace EducaRank.MVC.AutoMappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ViewModelToDomainMappingsProfile>();
                x.AddProfile<DomainToViewModelMappingsProfile>();
            });
        }
    }
}
