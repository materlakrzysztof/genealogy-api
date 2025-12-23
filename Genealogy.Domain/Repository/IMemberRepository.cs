using Genealogy.Domain.Entity;

namespace Genealogy.Domain.Repository;

public interface IMemberRepository
{
    Task<IEnumerable<FamilyMember>> SearchAsync(string searchTerm, int take = 10, int skip = 0);
    Task<FamilyMember> Create(FamilyMember familyMember);
    Task<FamilyMember> Update(FamilyMember familyMember);
}
