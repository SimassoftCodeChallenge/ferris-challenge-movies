using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ferris.Challenge.Movies.Infra.Repositories.Movie.Entity
{
    [DataContract]
    public class MovieCollectionEntity
    {
         [DataMember(Name="id")]        
        public int Id { get; set; }
        [DataMember(Name="name")]
        public string Name { get; set; }
        [DataMember(Name="poster_path")]
        public string PosterPath { get; set; }
        [DataMember(Name="backdrop_path")]
        public string BackdropPath { get; set; }
        [DataMember(Name="parts")]
        public List<MovieEntity> Parts { get; set; }
    }
}