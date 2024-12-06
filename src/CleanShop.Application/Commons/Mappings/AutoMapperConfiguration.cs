using AutoMapper;

namespace CleanShop.Application.Commons.Mappings
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                // Add mapping profiles here
            });
        }
    }
}
