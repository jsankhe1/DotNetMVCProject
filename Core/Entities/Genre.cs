using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Genre
{
    public int Id { get; set; }
    // removed the [required]  annotaiton
    [Column(TypeName = "nvarchar(25)")] public string? Name { get; set; }

    //Navigation Properties
    public ICollection<MovieGenre> MovieGenres { get; set; }
}