using Core.Entities;

public class MovieGenre
{
    public int MovieId { get; set; } // FK
    public int GenreId { get; set; } // FK
    // Navigation properties
    public Movie Movie { get; set; }
    public Genre Genre { get; set; }
}