using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Challenge.Movies.Infra.Common;
using Test.Challenge.Movies.Infra.DTO;
using Test.Challenge.Movies.Infra.DTO.Movies;

namespace Test.Challenge.Movies.Infra.Repositories
{
    [TestClass]
    public class MovieRepositoryTest
    {
        //FIXME: Enviar todas essas variáveis para um appSettings.json e dali extrair essas informações
        private static readonly HttpClient client = new HttpClient();
        private const string ENDPOINT_API_VERSAO4 = "https://api.themoviedb.org/4";
        private const string ENDPOINT_API_VERSAO3 = "https://api.themoviedb.org/3";
        private const string API_KEY = "bed90412e5ac5ce203465d7111fdb1f4";
        private const string API_READ_ACCESS_TOKEN = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJiZWQ5MDQxMmU1YWM1Y2UyMDM0NjVkNzExMWZkYjFmNCIsInN1YiI6IjVjYjlkODlhYzNhMzY4N2Y4ZjgwYTNlYiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.fdWNtT6TsEe4KbtvNwGCRTL_bB3FkqYOY3gOdOKPYSY";        
        
        /*
        Testes a serem efetuados:
        1) Tela de Dashboard
        1.1) Mostrar os seguintes serviços
        */
        /*
        1.1.1) Todos os filmes Lançados nos últimos 12 meses nos EUA em pt-br
        */
        [TestMethod]
        public async Task ShouldListAllMoviesReleasedLeastTewlveMonths()
        {
            var hoje = DateTime.Now.Date;
            var anoPassado = hoje.AddMonths(-12);
            var endpoint = $"/discover/movie?primary_release_date.gte={anoPassado.ToString("yyyy-MM-dd")}&primary_release_date.lte={hoje.ToString("yyyy-MM-dd")}&region=US&language=pt-BR&sort_by=popularity.desc";            
            ResponseDTO dto = null;

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",API_READ_ACCESS_TOKEN);
            await client.GetStringAsync($"{ENDPOINT_API_VERSAO4}{endpoint}").ContinueWith(x => {
                dto = Utils.SerializeToJson(x.Result, new ResponseDTO()) as ResponseDTO;
            });                                    
            Assert.AreEqual(1, dto.Page);
        }
        /*
        1.1.2) Filmes em destaque (Trending Movies) na atualidade
        */
        [TestMethod]
        public async Task ShouldListHighlightMovies()
        {   
            var endpoint = $"{ENDPOINT_API_VERSAO3}/trending/movie/day?api_key={API_KEY}";            
            client.DefaultRequestHeaders.Clear();
            ResponseDTO dto = null;            

            await client.GetStringAsync(endpoint).ContinueWith(x => {
                dto = Utils.SerializeToJson(x.Result, new ResponseDTO()) as ResponseDTO;
            });
            
            Assert.AreEqual(1, dto.Page);            
        }
        /*
        1.1.3) Filmes em cartaz nos cinemas do Brasil em pt-br
        */
        [TestMethod]
        public async Task ShouldListMoviesOnBrazilTheatres()
        {
            var endpoint = $"{ENDPOINT_API_VERSAO3}/movie/now_playing?api_key=bed90412e5ac5ce203465d7111fdb1f4&language=pt-BR&region=BR";            
            ResponseDTO dto = null;            

            client.DefaultRequestHeaders.Clear();
            await client.GetStringAsync(endpoint).ContinueWith(x => {
                dto = Utils.SerializeToJson(x.Result, new ResponseDTO()) as ResponseDTO;
            });
            Assert.AreEqual(1, dto.Page);            
        }

        /*
        1.1.4) Filmes com votação mais alta
        */
        [TestMethod]
        public async Task ShouldListMoviesWithVotationHigher()
        {
            //var endpoint = $"{ENDPOINT_API_VERSAO4}/discover/movie?primary_release_date.gte=2018-04-15&primary_release_date.lte=2019-04-15&region=US&language=pt-BR&sort_by=vote_average.desc";
            var hoje = DateTime.Now.Date;
            var anoPassado = hoje.AddMonths(-12);
            var endpoint = $"{ENDPOINT_API_VERSAO4}/discover/movie?primary_release_date.gte={anoPassado.ToString("yyyy-MM-dd")}&primary_release_date.lte={hoje.ToString("yyyy-MM-dd")}&region=US&language=pt-BR&sort_by=vote_average.desc";
            ResponseDTO dto = null;

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",API_READ_ACCESS_TOKEN);
            //var resultado = await client.GetStringAsync(endpoint);
            await client.GetStringAsync(endpoint).ContinueWith(x => {
                dto = Utils.SerializeToJson(x.Result, new ResponseDTO()) as ResponseDTO;
            });
            //dto = Utils.SerializeToJson(resultado, new ResponseDTO()) as ResponseDTO;
            Assert.AreEqual(1,dto.Page);
        }
        /*
        1.1.5) Filmes mais Populares
        */
        [TestMethod]
        public async Task ShouldListMostPopularMovie()
        {
            var hoje = DateTime.Now.Date;
            var anoPassado = hoje.AddMonths(-12);
            var endpoint = $"{ENDPOINT_API_VERSAO4}/discover/movie?primary_release_date.gte={anoPassado.ToString("yyyy-MM-dd")}&primary_release_date.lte={hoje.ToString("yyyy-MM-dd")}&region=US&language=pt-BR&sort_by=popularity.desc";
            ResponseDTO dto = null;

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",API_READ_ACCESS_TOKEN);
            //var resultado = await client.GetStringAsync(endpoint);
            await client.GetStringAsync(endpoint).ContinueWith(x => {
                dto = Utils.SerializeToJson(x.Result, new ResponseDTO()) as ResponseDTO;
            });
            //dto = Utils.SerializeToJson(resultado, new ResponseDTO()) as ResponseDTO;
            Assert.AreEqual(1,dto.Page);
        }
        /*
        1.2) Seção de Busca
        /*
        1.2.1) Buscar título por palavra chave em pt-br
        */
        [TestMethod]
        public async Task ShouldListAllMoviesSearchedbyKeyword()
        {
            var searchWords = "Homem Aranha";
            var keywords = searchWords.Replace(' ','+');
            var endpoint = $"{ENDPOINT_API_VERSAO4}/search/movie?query={keywords}&include_adult=false&language=pt-BR";
            ResponseDTO dto = null;

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",API_READ_ACCESS_TOKEN);
            //var resultado = await client.GetStringAsync(endpoint);
            await client.GetStringAsync(endpoint).ContinueWith(x => {
                dto = Utils.SerializeToJson(x.Result, new ResponseDTO()) as ResponseDTO;                                
            });

            if (dto.results.Count > 1)
            {
                var filmesOrdenadosPorDataDeLancamento = dto.results.Where(x => DateTime.Parse(x.ReleaseDate) >= DateTime.Now.Date.AddMonths(-12) && DateTime.Parse(x.ReleaseDate) <= DateTime.Now.Date).OrderByDescending(x => DateTime.Parse(x.ReleaseDate)).ToList<MovieDTO>();                
                if (filmesOrdenadosPorDataDeLancamento != null && filmesOrdenadosPorDataDeLancamento.Count > 0){
                    dto.results.Clear();
                    dto.TotalResult = filmesOrdenadosPorDataDeLancamento.Count;
                    dto.TotalPages = Math.Abs(filmesOrdenadosPorDataDeLancamento.Count / 20) + 1;
                    dto.results.AddRange(filmesOrdenadosPorDataDeLancamento);
                }    
            }            

            Assert.AreEqual(1,dto.Page);
        }
        /*
        1.2.2) Mostrar os detalhes do filme que foi localizado
        */
        [TestMethod]
        public async Task ShouldShowMovieDetailsById()
        {
            int id = 324857;
            var endpoint = $"{ENDPOINT_API_VERSAO3}/movie/{id}?api_key={API_KEY}";
            DetailDTO dto = null;

            client.DefaultRequestHeaders.Clear();
            await client.GetStringAsync(endpoint).ContinueWith(x => {
                dto = Utils.SerializeToJson(x.Result, new DetailDTO()) as DetailDTO;
            });
            Assert.AreEqual(324857, dto.Id);
        }
        /*
        OBS.: Cada item destes se tornará um módulo no Angular
        */

    }
}