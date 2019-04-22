using AutoMapper;
using Ferris.Challenge.Movies.Infra.Mappers.Profiles;

namespace Ferris.Challenge.Movies.Infra.Mappers
{
    public class MapperConfig
    {
        public MapperConfig()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => {
               cfg.AddProfile<ModelToEntityProfile>();
               cfg.AddProfile<EntityToModelProfile>();
            });
        }
    }
}