using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Purchases
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int UserId { get; set; }

    [Column(TypeName = "DATETIME2")] public DateTime PurchaseDateTime { get; set; }
    [Column(TypeName = "DECIMAL(3,2)")] public decimal TotalPrice { get; set; }
    public Guid PurchaseNumber { get; set; }
    
    // navigation properties
    public Movie Movie { get; set; } = new Movie();
    public User User { get; set; } = new User();

}