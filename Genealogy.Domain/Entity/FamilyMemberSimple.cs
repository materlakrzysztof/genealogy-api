namespace Genealogy.Domain.Entity;

public record FamilyMemberSimple(int id, string FirstName, string LastName, string? MaidenName, DateTime? BirthDate, DateTime? DeathDate)
{
}
