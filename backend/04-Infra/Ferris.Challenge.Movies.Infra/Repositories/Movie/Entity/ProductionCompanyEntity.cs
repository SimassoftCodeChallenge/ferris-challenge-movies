using System.Runtime.Serialization;

namespace Ferris.Challenge.Movies.Infra.Repositories.Movie.Entity
{
    [DataContract]
    public class ProductionCompanyEntity
    {
        [DataMember(Name="name")]
        public string Name { get; set; }
        [DataMember(Name="id")]
        public int Id { get; set; }
        [DataMember(Name="logo_path")]
        public string LogoPath { get; set; }
        [DataMember(Name="origin_country")]
        public string OriginCountry { get; set; }
    }
}