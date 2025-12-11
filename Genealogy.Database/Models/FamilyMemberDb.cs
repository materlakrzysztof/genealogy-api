
namespace Genealogy.Database.Models;

public class FamilyMemberDb
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string? MaidenName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string? PlaceOfDeath { get; set; }
    public int Gender { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Relationships
    public int? CreatedByUserId { get; set; }
    public UserDb? CreatedBy { get; set; }

    //// Parent relationships
    //public ICollection<FamilyRelationship> AsChild { get; set; } = new List<FamilyRelationship>();

    //// Child relationships
    //public ICollection<FamilyRelationship> AsParent { get; set; } = new List<FamilyRelationship>();

    //// Spouse relationships
    //public ICollection<Marriage> AsSpouse1 { get; set; } = new List<Marriage>();
    //public ICollection<Marriage> AsSpouse2 { get; set; } = new List<Marriage>();
}
