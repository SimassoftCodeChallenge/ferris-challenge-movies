using System.Collections.Generic;

namespace Ferris.Challenge.Movies.Domain.Model
{
    public class Detail
    {  
        public int? Budget { get; set; }                        
        public string Homepage { get; set; }
        public string ImdbId { get; set; }
        public int? Revenue { get; set; }
        public int? Runtime { get; set; }        
        public string Status { get; set; }
        public string Tagline { get; set; } 
        //FIXME: Transformar os Lists em Classes com sufixo Collection
        public List<MovieCollection> BelongsToCollection { get; set; }        
        public List<Genre> Genres { get; set; }   
        public List<ProductionCompany> ProductionCompanies { get; set; }        
        public List<ProductionCountry> ProductionCountries { get; set; } 
        public List<SpokenLanguage> SpokenLanguages { get; set; }      
    }
}