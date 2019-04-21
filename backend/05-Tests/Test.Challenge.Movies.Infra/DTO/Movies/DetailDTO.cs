using System.Collections.Generic;
using System.Runtime.Serialization;

using Test.Challenge.Movies.Infra.DTO.Production;

namespace Test.Challenge.Movies.Infra.DTO.Movies
{
    [DataContract]
    public class DetailDTO: MovieDTO
    {
        [DataMember(Name="budget")]
        public int? Budget { get; set; }                        
        [DataMember(Name="homepage")]
        public string Homepage { get; set; }
        [DataMember(Name="imdb_id")]
        public string ImdbId { get; set; }
        [DataMember(Name="revenue")]
        public int? Revenue { get; set; }
        [DataMember(Name="runtime")]
        public int? Runtime { get; set; }        
        [DataMember(Name="status")]
        public string Status { get; set; }
        [DataMember(Name="tagline")]
        public string Tagline { get; set; } 
        //FIXME: Transformar os Lists em Classes com sufixo Collection
        [DataMember(Name="belongs_to_collection")]
        public List<CollectionDTO> BelongsToCollection { get; set; }        
        [DataMember(Name="genres")]
        public List<GenreDTO> Genres { get; set; }   
        [DataMember(Name="production_companies")]
        public List<CompanyDTO> ProductionCompanies { get; set; }   
        [DataMember(Name="production_countries")]
        public List<CountryDTO> ProductionCountries { get; set; } 
        [DataMember(Name="spoken_languages")]
        public List<SpokenLanguageDTO> SpokenLanguages { get; set; }          
    }
}