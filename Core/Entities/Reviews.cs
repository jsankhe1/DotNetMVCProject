using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Reviews
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int UserId { get; set; }

    [Column(TypeName = "DATETIME2")] public DateTime CreatedAt { get; set; }
    [Column(TypeName = "DECIMAL(3,2)")] public decimal Rating { get; set; }
    [Column(TypeName = "Nvarchar(MAX)")] public string ReviewText { get; set; }

    //navigation properties
    public Movie Movie { get; set; } = new Movie();
    public User User { get; set; } = new User();
}