using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core.Entities;

public class User
{
    public int Id { get; set; }
    [Column(TypeName = "DATETIME2")] public DateTime DateOfBirth { get; set; }
    [Column(TypeName = "nvarchar(256)")] public string Email { get; set; }
    [Column(TypeName = "nvarchar(128)")] public string FirstName { get; set; }
    [Column(TypeName = "nvarchar(128)")] public string LastName { get; set; }
    [Column(TypeName = "nvarchar(1024)")] public string HashedPassword { get; set; }
    public bool? IsLocked { get; set; }
    [Column(TypeName = "nvarchar(16)")] public string? PhoneNumber { get; set; }
    public string? ProfileUrl { get; set; }
    [Column(TypeName = "nvarchar(1024)")] public string Salt { get; set; }

    //Navigation Property
    public ICollection<Favorites> Favorites { get; set; } = new List<Favorites>();
    public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
    public ICollection<Purchases> Purchases { get; set; } = new List<Purchases>();
    public ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
}