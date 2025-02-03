using Core.Entities;

namespace Core.Models;

public class MovieDetailsModel
{
    //Basic Movie Deets
    public int Id { get; set; }
    public string Title{ get; set; }
    public string TagLine { get; set; }
    public string Overview { get; set; }
    public decimal? Rating { get; set; }
    public decimal? Price { get; set; }
    public string PosterUrl { get; set; }
    public string BackdropUrl { get; set; }
    public List<string?> Genres { get; set; }
    
    // MovieFacts
    public DateTime? ReleaseDate { get; set; }
    public int Runtime { get; set; }
    public decimal? BoxOffice { get; set; }
    public decimal?  Budget { get; set; }
    
    //Cast and Trailer Model links
    public IEnumerable<MovieCastModel> CastModels { get; set; }
    public IEnumerable<MovieTrailerModel> TrailerModels { get; set; }
}