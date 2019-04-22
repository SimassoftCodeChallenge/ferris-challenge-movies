using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ferris.Challenge.Movies.Infra.Repositories.Movie.Entity
{
    [DataContract]
    public class DetailsEntity
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
        public List<MovieCollectionEntity> BelongsToCollection { get; set; }        
        [DataMember(Name="genres")]
        public List<GenreEntity> Genres { get; set; }   
        [DataMember(Name="production_companies")]
        public List<ProductionCompanyEntity> ProductionCompanies { get; set; }   
        [DataMember(Name="production_countries")]
        public List<ProductionCountryEntity> ProductionCountries { get; set; } 
        [DataMember(Name="spoken_languages")]
        public List<SpokenLanguageEntity> SpokenLanguages { get; set; }  
    }
}