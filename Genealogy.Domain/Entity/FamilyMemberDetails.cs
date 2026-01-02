namespace Genealogy.Domain.Entity;

public class FamilyMemberDetails
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string? MaidenName { get; set; }
    public Gender Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? BirthPlace { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? DeathPlace { get; set; }

    public string? Notes { get; set; }
}
