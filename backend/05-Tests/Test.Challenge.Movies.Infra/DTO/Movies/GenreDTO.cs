using System.Runtime.Serialization;

namespace Test.Challenge.Movies.Infra.DTO.Movies
{
    [DataContract]
    public class GenreDTO
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
        [DataMember(Name="name")]
        public string Name { get; set; }
    }
}