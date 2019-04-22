using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Test.Challenge.Movies.Infra.DTO.Movies
{
    [DataContract]
    public class CollectionDTO
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
        public List<MovieDTO> Parts { get; set; }        

    }
}