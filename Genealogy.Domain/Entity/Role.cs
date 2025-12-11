namespace Genealogy.Domain.Entity;

[Flags]
public enum Role
{
    None = 0,
    User = 1 << 0,
    Admin = 1 << 1,
}
