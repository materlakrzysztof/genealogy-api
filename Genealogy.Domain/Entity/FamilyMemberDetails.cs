namespace Genealogy.Domain.Entity;

public class FamilyMemberDetails
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string? MaidenName { get; set; }
    public Gender Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PlaceOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public string? PlaceOfDeath { get; set; }

    public string? Notes { get; set; }
}
