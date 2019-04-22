using System.Runtime.Serialization;

namespace Test.Challenge.Movies.Infra.DTO.Movies
{
    [DataContract]
    public class SpokenLanguageDTO
    {
        [DataMember(Name="iso_639_1")]
        public string Iso6391 { get; set; }
        [DataMember(Name="name")]
        public string Name { get; set; }
    }
}