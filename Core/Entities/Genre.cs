using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Genres
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is Required")] [Column(TypeName = "nvarchar(25")]
    public string Name { get; set; }
}