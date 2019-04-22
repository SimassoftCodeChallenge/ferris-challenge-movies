using System.Runtime.Serialization;

namespace Ferris.Challenge.Movies.Infra.Repositories.Movie.Entity
{
    [DataContract]
    public class ProductionCountryEntity
    {
        [DataMember(Name="iso_3166_1")]
        public string Iso31661  { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }
    }
}