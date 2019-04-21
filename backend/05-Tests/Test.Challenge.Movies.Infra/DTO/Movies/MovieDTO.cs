using System.Runtime.Serialization;

namespace Test.Challenge.Movies.Infra.DTO.Movies
{
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
}