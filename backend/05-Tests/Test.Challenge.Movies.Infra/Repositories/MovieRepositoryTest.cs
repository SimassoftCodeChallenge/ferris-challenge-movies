using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Challenge.Movies.Infra.Repositories
{
    [TestClass]
    public class MovieRepositoryTest
    {
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
            //var serializer = new DataContractJsonSerializer(typeof(MovieResponseDTO));

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",API_READ_ACCESS_TOKEN);
            var resultado = await client.GetStringAsync($"{ENDPOINT_API_VERSAO4}{endpoint}");            
            //var repositories = serializer.ReadObject(resultado) as MovieResponseDTO;
            /*MovieResponseDTO dto = new MovieResponseDTO();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(resultado)); 
            DataContractJsonSerializer ser = new DataContractJsonSerializer(dto.GetType());  
            dto = ser.ReadObject(ms) as MovieResponseDTO;
            ms.Close();*/
            var dto = Utils.SerializaToJson(resultado, new MovieResponseDTO()) as MovieResponseDTO;
            Assert.AreEqual(1, dto.Page);
        }
        /*
        1.1.2) Filmes em destaque (Trending Movies) na atualidade
        */
        /*
        1.1.3) Filmes em cartaz nos cinemas do Brasil em pt-br
        */
        /*
        1.1.4) Filmes com votação mais alta
        */
        /*
        1.1.5) Filmes mais populares
        1.2) Seção de Busca
        /*
        1.2.1) Buscar título por palavra chave em pt-br
        */
        /*
        1.2.2) Mostrar os detalhes do filme que foi localizado
        */
        /*
        OBS.: Cada item destes se tornará um módulo no Angular
        */
    }

    [DataContract]
    public class MovieResponseDTO{
        private int? _nextPage;
        private int? _priorPage; 
        private int? _firstPage;
        private int? _lastPage;
        private int? _resultsPerPage;       
        private int _page;
        private int _totalPages;

        [DataMember(Name="page")]        
        public int Page { 
            get {
                if (_page > 0)
                {
                    _priorPage = _page > 1 ? _page - 1 : 0;
                    _nextPage = _page < _totalPages ? _page + 1: 0; 
                    _lastPage = _totalPages > 0 ? _totalPages : 0;
                    _firstPage = 1;
                }            
                return _page;
            }

            set { _page = value;} }

        [DataMember(Name="total_results")]
        public int TotalResult {get; set;}

        [DataMember(Name="total_pages")]    
        public int TotalPages
        {
            get => _totalPages;
            set => _totalPages = value;
        }
        public int? PriorPage { get => _priorPage; }
        public int? NextPage  { get => _nextPage; }
        public int? FirstPage { get => _firstPage; }
        public int? LastPage  { get => _lastPage; }
        public int? ResultsPerPage => TotalResult / TotalPages;

        [DataMember(Name="results")]
        public List<MovieDTO> results;
    }

    [DataContract]
    public class MovieDTO
    {   
        [DataMember(Name="poster_path")]
        public string PosterPath { get; set; }

        [DataMember(Name="adult")]
        public bool IsAdultContent { get; set; } 

        [DataMember(Name="overview")]
        public string Overview { get; set; }

        [DataMember(Name="release_date")]
        public string ReleaseDate { get; set; }

        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name="original_title")]
        public string OriginalTitle { get; set; }

        [DataMember(Name="original_language")]
        public string OriginalLanguage { get; set; }

        [DataMember(Name="title")]
        public string Title { get; set; }

        [DataMember(Name="backdrop_path")]
        public string BackdropPath { get; set; }

        [DataMember(Name="popularity")]
        public decimal Popularity { get; set; }

        [DataMember(Name="vote_count")]
        public int VoteCount { get; set; }

        [DataMember(Name="video")]
        public bool HasVideo { get; set; }

        [DataMember(Name="vote_average")]
        public decimal VoteAverage {get; set;}

        [DataMember(Name="genre_ids")]
        public int[] genres { get; set; }
    }

    public static class Utils
    {
        public static object SerializaToJson(string json, object objectInput)
        {
            var dto = Activator.CreateInstance(objectInput.GetType());
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)); 
            DataContractJsonSerializer ser = new DataContractJsonSerializer(dto.GetType());  
            dto = ser.ReadObject(ms);
            ms.Close();
            return dto;
        }
    }    
}