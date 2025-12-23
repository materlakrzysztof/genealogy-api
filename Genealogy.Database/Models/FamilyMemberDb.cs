
namespace Genealogy.Database.Models;

public class FamilyMemberDb
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string? MaidenName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PlaceOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public string? PlaceOfDeath { get; set; }

    public int Gender { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    ////// Parent relationships
    //public ICollection<FamilyMemberDb> Children { get; set; } = new List<FamilyMemberDb>();
    //public ICollection<FamilyMemberDb> Parents { get; set; } = new List<FamilyMemberDb>();

    //// Child relationships
    //public ICollection<FamilyRelationship> AsParent { get; set; } = new List<FamilyRelationship>();

    //// Spouse relationships
    //public ICollection<Marriage> AsSpouse1 { get; set; } = new List<Marriage>();
    //public ICollection<Marriage> AsSpouse2 { get; set; } = new List<Marriage>();
}
