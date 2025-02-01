using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Movie
{
    public int Id { get; set; }
    public string? Tagline { get; set; }
    public string? Title { get; set; }
    public string? Overview { get; set; }
    public int Runtime { get; set; }
    public decimal? Budget { get; set; }
    public string? OriginalLanguage { get; set; }
    public decimal? Price { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public decimal? Revenue { get; set; }

    

    [Column(TypeName = "nvarchar(2084)")] public string? TmdbUrl { get; set; }
    [Column(TypeName = "nvarchar(2084)")] public string? ImdbUrl { get; set; }
    [Column(TypeName = "nvarchar(2084)")] public string? BackdropUrl { get; set; }
    [Column(TypeName = "nvarchar(2084)")] public string? PosterUrl { get; set; }


    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    
    //Navigation Properties
    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>(); 
    public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
    public ICollection<Trailer> Trailers { get; set; } = new List<Trailer>();
    public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
    public ICollection<Purchases> Purchases { get; set; } = new List<Purchases>();
    
}

