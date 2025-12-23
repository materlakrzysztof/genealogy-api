using Genealogy.Domain.Entity;

namespace GenealogyApi.Requests;

public class MemberRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? MaidenName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? BirthPlace { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? DeathPlace { get; set; }
    public Gender Gender { get; set; } = Gender.Male;
    public string? Notes { get; set; }


}
