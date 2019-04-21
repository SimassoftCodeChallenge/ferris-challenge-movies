using System.Runtime.Serialization;

namespace Test.Challenge.Movies.Infra.DTO.Production
{
    [DataContract]
    public class CountryDTO
    {
        [DataMember(Name="iso_3166_1")]
        public string Iso31661  { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }
    }
}