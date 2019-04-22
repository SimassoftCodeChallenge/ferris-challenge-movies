using System.Collections.Generic;
using System.Threading.Tasks;
using Ferris.Challenge.Movies.Domain.Contracts.Repositories;
using Ferris.Challenge.Movies.Domain.Contracts.Services;
using Ferris.Challenge.Movies.Domain.Model;

namespace Ferris.Challenge.Movies.Domain.Services
{
    public class MovieDomainService : IMovieDomainService
    {
        private readonly IMovieRepository _repository;

        public MovieDomainService(IMovieRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Movie>> FeaturedMovies()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<Movie> FindMoviesByKeyword(string keyword)
        {
            //TODO: Movie já deve trazer Detail hidratada com ele.
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Movie>> MostPopularMovies()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Detail> MovieDetailById(int id)
        {
            return await _repository.FindMovieDetailById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Movie>> MoviesOnDisplayInBrazilianCinema()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Movie>> MoviesReleasedInOneYear()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Movie>> TopRatedMovies()
        {
            throw new System.NotImplementedException();
        }
    }
}