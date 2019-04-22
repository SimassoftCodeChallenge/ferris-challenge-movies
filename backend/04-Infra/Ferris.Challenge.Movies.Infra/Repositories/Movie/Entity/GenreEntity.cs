using System.Runtime.Serialization;

namespace Ferris.Challenge.Movies.Infra.Repositories.Movie.Entity
{
    [DataContract]
    public class GenreEntity
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
        [DataMember(Name="name")]
        public string Name { get; set; }
    }
}