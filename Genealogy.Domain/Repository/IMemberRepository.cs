using Genealogy.Domain.Entity;

namespace Genealogy.Domain.Repository;

public interface IMemberRepository
{
    Task<IEnumerable<FamilyMemberSimple>> SearchAsync(string searchTerm, int take = 10, int skip = 0);
    Task<FamilyMember> Create(FamilyMember familyMember);
    Task<FamilyMember> Update(FamilyMember familyMember);

    Task<FamilyMember> FindById (int id);
    Task<FamilyMember> RemoveById(FamilyMember member);
}
