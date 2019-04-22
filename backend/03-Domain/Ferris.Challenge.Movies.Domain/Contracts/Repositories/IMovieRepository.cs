using System.Collections.Generic;
using System.Threading.Tasks;
using Ferris.Challenge.Movies.Domain.Model;

namespace Ferris.Challenge.Movies.Domain.Contracts.Repositories
{
    public interface IMovieRepository
    {
        //Teste => ListAllMoviesReleasedLeastTewlveMonths        
        Task<Movie> ListMoviesReleasedInOneYear();
        //Teste => ShouldListHighlightMovies
        Task<Movie> ListFeaturedMovies();
        //Teste => ShouldListMoviesOnBrazilTheatres
        Task<Movie> ListMoviesOnDisplayInBrazilianCinema();
        //Teste => ShouldListMoviesWithVotationHigher
        Task<Movie> ListTopRatedMovies();        
        //Teste => ShouldListMostPopularMovie
        Task<Movie> ListMostPopularMovies();
        //Teste => ShouldListAllMoviesSearchedbyKeyword
        Task<List<Movie>> FindMoviesByKeyword(string keyword);
        Task<Detail> FindMovieDetailById(int id);
    }
}