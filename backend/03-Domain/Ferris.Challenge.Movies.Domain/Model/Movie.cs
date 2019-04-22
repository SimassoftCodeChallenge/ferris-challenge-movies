using System.Collections.Generic;

namespace Ferris.Challenge.Movies.Domain.Model
{
    public class Movie
    {

        public Movie(string posterPath, bool isAdultContent, string overview, string releaseDate, int id, string originalTitle, string originalLanguage, string title, string backdropPath, decimal popularity, int voteCount, bool hasVideo, decimal voteAverage, Detail movieDetail)
        {
            this.PosterPath = posterPath;
            this.IsAdultContent = isAdultContent;
            this.Overview = overview;
            this.ReleaseDate = releaseDate;
            this.Id = id;
            this.OriginalTitle = originalTitle;
            this.OriginalLanguage = originalLanguage;
            this.Title = title;
            this.BackdropPath = backdropPath;
            this.Popularity = popularity;
            this.VoteCount = voteCount;
            this.HasVideo = hasVideo;
            this.VoteAverage = voteAverage;            
        }
        public string PosterPath { get; private set; }

        public bool IsAdultContent { get; private set; }

        public string Overview { get; private set; }

        public string ReleaseDate { get; private set; }

        public int Id { get; private set; }

        public string OriginalTitle { get; private set; }

        public string OriginalLanguage { get; private set; }

        public string Title { get; private set; }

        public string BackdropPath { get; private set; }

        public decimal Popularity { get; private set; }

        public int VoteCount { get; private set; }

        public bool HasVideo { get; private set; }
        public decimal VoteAverage { get; private set; }        
        public List<Genre> genres { get; private set; }
    }
}