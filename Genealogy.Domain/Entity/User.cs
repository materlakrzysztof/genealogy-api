
namespace Genealogy.Domain.Entity;

public record User (int Id, string UserName, string PasswordHash, DateTime CreateDate, bool Active, Role Role)
{
}