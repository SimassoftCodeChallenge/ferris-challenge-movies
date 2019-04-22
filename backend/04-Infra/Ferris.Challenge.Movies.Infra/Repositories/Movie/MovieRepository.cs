using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Ferris.Challenge.Movies.Domain.Contracts.Repositories;
using Ferris.Challenge.Movies.Domain.Model;
using Ferris.Challenge.Movies.Infra.Common;
using Ferris.Challenge.Movies.Infra.Repositories.Movie.Entity;

namespace Ferris.Challenge.Movies.Infra.Repositories.Movie
{
    public class MovieRepository : IMovieRepository
    {       
        /*private static readonly HttpClient client = new HttpClient();
        private const string ENDPOINT_API_VERSAO4 = "https://api.themoviedb.org/4";
        private const string ENDPOINT_API_VERSAO3 = "https://api.themoviedb.org/3";
        private const string API_KEY = "bed90412e5ac5ce203465d7111fdb1f4";
        private const string API_READ_ACCESS_TOKEN = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJiZWQ5MDQxMmU1YWM1Y2UyMDM0NjVkNzExMWZkYjFmNCIsInN1YiI6IjVjYjlkODlhYzNhMzY4N2Y4ZjgwYTNlYiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.fdWNtT6TsEe4KbtvNwGCRTL_bB3FkqYOY3gOdOKPYSY";      
        */
        public async Task<Domain.Model.Detail> FindMovieDetailById(int id)
        {
            string endpoint = $"/movie/{id}";
            //Traz o detail
            var detailEntity = await UseApiVersion3Async(endpoint, new DetailsEntity());                                    
            return Mapper.Map<Detail>(detailEntity);
        }
        public Task<List<Domain.Model.Movie>> FindMoviesByKeyword(string keyword)
        {
            throw new System.NotImplementedException();
        }
        public Task<Domain.Model.Movie> ListFeaturedMovies()
        {
            throw new System.NotImplementedException();
        }
        public Task<Domain.Model.Movie> ListMostPopularMovies()
        {
            throw new System.NotImplementedException();
        }
        public Task<Domain.Model.Movie> ListMoviesOnDisplayInBrazilianCinema()
        {
            throw new System.NotImplementedException();
        }
        public Task<Domain.Model.Movie> ListMoviesReleasedInOneYear()
        {
            throw new System.NotImplementedException();
        }
        public Task<Domain.Model.Movie> ListTopRatedMovies()
        {
            throw new System.NotImplementedException();
        }

        private async Task<object> UseApiVersion4Async(string endpoint,object objectInput)
        {
            string EndpointApiV4 = "https://api.themoviedb.org/4";
            string AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJiZWQ5MDQxMmU1YWM1Y2UyMDM0NjVkNzExMWZkYjFmNCIsInN1YiI6IjVjYjlkODlhYzNhMzY4N2Y4ZjgwYTNlYiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.fdWNtT6TsEe4KbtvNwGCRTL_bB3FkqYOY3gOdOKPYSY";                  
            object dto = null;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",AccessToken);
            await client.GetStringAsync($"{EndpointApiV4}{endpoint}").ContinueWith(x => {
                dto = Utils.SerializeToJson(x.Result,objectInput);
            });
            return dto;
        }  

        private async Task<object> UseApiVersion3Async(string endpoint,object objectInput)
        {
            string EndpointApiV3 = "https://api.themoviedb.org/3";
            string ApiKey = "bed90412e5ac5ce203465d7111fdb1f4";
            object dto = null;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();            
            await client.GetStringAsync($"{EndpointApiV3}{endpoint}?api_key={ApiKey}").ContinueWith(x => {
                dto = Utils.SerializeToJson(x.Result,objectInput);
            });
            return dto;
        }      
    }
}