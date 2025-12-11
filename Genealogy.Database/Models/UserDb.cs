namespace Genealogy.Database.Models;

public class UserDb
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime? CreateDate { get; set; }
    public bool Active { get; set; } = true;
    public int Role { get; set; }
}