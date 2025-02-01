using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Core.Entities;

public class Cast
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(25)")]
    public string Name { get; set; }
    public string Gender { get; set; }
    public string TmdbUrl { get; set; }
    public string ProfilePath { get; set; }
    
    //navigation Properties
    public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();

    
}