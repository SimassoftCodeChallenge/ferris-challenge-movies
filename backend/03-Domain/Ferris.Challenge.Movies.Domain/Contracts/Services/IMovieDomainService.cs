using System.Collections.Generic;
using System.Threading.Tasks;
using Ferris.Challenge.Movies.Domain.Model;

namespace Ferris.Challenge.Movies.Domain.Contracts.Services
{
    public interface IMovieDomainService
    {
        Task<Detail> MovieDetailById(int id);
        //Teste => ListAllMoviesReleasedLeastTewlveMonths        
        Task<List<Movie>> MoviesReleasedInOneYear();
        //Teste => ShouldListHighlightMovies
        Task<List<Movie>> FeaturedMovies();
        //Teste => ShouldListMoviesOnBrazilTheatres
        Task<List<Movie>> MoviesOnDisplayInBrazilianCinema();
        //Teste => ShouldListMoviesWithVotationHigher
        Task<List<Movie>> TopRatedMovies();        
        //Teste => ShouldListMostPopularMovie
        Task<List<Movie>> MostPopularMovies();
        //Teste => ShouldListAllMoviesSearchedbyKeyword
        Task<Movie> FindMoviesByKeyword(string keyword);
    }
}