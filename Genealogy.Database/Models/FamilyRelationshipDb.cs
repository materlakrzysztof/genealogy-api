
namespace Genealogy.Database.Models;

public class FamilyRelationship
{
    public Guid Id { get; set; }

    // Osoba źródłowa (np. dziecko)
    public Guid SourceMemberId { get; set; }
    public FamilyMemberDb SourceMember { get; set; } = null!;

    // Osoba docelowa (np. rodzic)
    public Guid TargetMemberId { get; set; }
    public FamilyMemberDb TargetMember { get; set; } = null!;

    // Typ relacji
    public RelationshipType RelationshipType { get; set; }

    public DateTime CreatedAt { get; set; }
}

public enum RelationshipType
{
    Parent,         // Rodzic
    Child,          // Dziecko
    Spouse,         // Małżonek/Partner
}
