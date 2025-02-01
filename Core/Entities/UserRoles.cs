namespace Core.Entities;

public class UserRoles
{
    public int RoleId { get; set; }
    public int UserId { get; set; }
    
    //Navigation Properties
    public User User { get; set; } = new User();
    public Role Role { get; set; } = new Role();
}