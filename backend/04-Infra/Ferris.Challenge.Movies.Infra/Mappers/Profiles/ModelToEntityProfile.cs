using AutoMapper;
using Ferris.Challenge.Movies.Domain.Model;
using Ferris.Challenge.Movies.Infra.Repositories.Movie.Entity;

namespace Ferris.Challenge.Movies.Infra.Mappers.Profiles
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<Movie,MovieEntity>(); 
            CreateMap<Detail,DetailsEntity>();
        }
    }
}