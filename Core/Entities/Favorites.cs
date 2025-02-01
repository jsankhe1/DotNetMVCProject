namespace Core.Entities;

public class Favorites
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    
    //navigation prop
    public Movie Movie { get; set; }
    public User User { get; set; }
}