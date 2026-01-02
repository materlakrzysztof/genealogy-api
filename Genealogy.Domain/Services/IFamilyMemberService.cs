using Genealogy.Domain.Entity;

namespace Genealogy.Domain.Services;

public interface IFamilyMemberService
{
    Task<FamilyMember> CreateNew(FamilyMemberDetails details);
    Task<FamilyMember> Update(int id, FamilyMemberDetails details);

    Task<FamilyMember> Get(int id);
    Task<FamilyMember> Remove(int id);
    Task<IEnumerable<FamilyMemberSimple>> GetMembers(string? searchTerm, int page = 1, int limit = 20);
}
