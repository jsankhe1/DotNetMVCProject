using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Role
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(20)")] public string Name { get; set; } = string.Empty;
    
    //Navigation Property
    public ICollection<UserRoles> UserRolesCollection { get; set; } = new List<UserRoles>();

}