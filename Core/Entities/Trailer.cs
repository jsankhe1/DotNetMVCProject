using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Trailer
{
    public int Id { get; set; }
    
    [Column(TypeName = "NVARCHAR(2084)")] public string TrailerUrl { get; set; }
    [Column(TypeName = "NVARCHAR(2084)")] public string Name { get; set; }
    public int MovieId { get; set; }

    // Navigation Property
    public Movie Movie { get; set; } = new Movie();
}