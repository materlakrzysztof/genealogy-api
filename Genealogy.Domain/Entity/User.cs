
namespace Genealogy.Domain.Entity;

public record User (int Id, string UserName, DateTime CreateDate, bool Active, Role Role)
{
}