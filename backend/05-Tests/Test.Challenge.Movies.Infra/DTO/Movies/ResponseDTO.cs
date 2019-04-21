using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Test.Challenge.Movies.Infra.DTO.Movies
{
    [DataContract]
    public class ResponseDTO
    {
        private int? _nextPage;
        private int? _priorPage; 
        private int? _firstPage;
        private int? _lastPage;
        private int? _resultsPerPage;       
        private int _page;
        private int _totalPages;

        [DataMember(Name="page")]        
        public int Page { 
            get {
                if (_page > 0)
                {
                    _priorPage = _page > 1 ? _page - 1 : 0;
                    _nextPage = _page < _totalPages ? _page + 1: 0; 
                    _lastPage = _totalPages > 0 ? _totalPages : 0;
                    _firstPage = 1;
                }            
                return _page;
            }

            set { _page = value;} }

        [DataMember(Name="total_results")]
        public int TotalResult {get; set;}

        [DataMember(Name="total_pages")]    
        public int TotalPages
        {
            get => _totalPages;
            set => _totalPages = value;
        }
        public int? PriorPage { get => _priorPage; }
        public int? NextPage  { get => _nextPage; }
        public int? FirstPage { get => _firstPage; }
        public int? LastPage  { get => _lastPage; }
        public int? ResultsPerPage => TotalResult / TotalPages;

        //FIXME: Trocar o tipo Lista criando uma Classe de Collection
        [DataMember(Name="results")]
        public List<MovieDTO> results;
    }
}