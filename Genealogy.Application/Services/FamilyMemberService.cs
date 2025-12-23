using Genealogy.Domain.Entity;
using Genealogy.Domain.Repository;
using Genealogy.Domain.Services;
using Mapster;

namespace Genealogy.Application.Services;

public class FamilyMemberService(IMemberRepository memberRepository) : IFamilyMemberService
{
    public async Task<FamilyMember> CreateNew(FamilyMemberDetails details)
    {
        var memberData = details.Adapt<FamilyMember>();
        var member = await memberRepository.Create(memberData);
        return member;
    }

    public async Task<IEnumerable<FamilyMember>> GetMembers(string? searchTerm, int page = 1, int limit = 20)
    {
        var skip = page > 0 ?  page - 1 : 0;

        var term = searchTerm ?? string.Empty;

        var members = await memberRepository.SearchAsync(term, limit, skip);
        return members;
    }


    public async Task<FamilyMember> Update(int id, FamilyMemberDetails details)
    {
        var memberData = details as FamilyMember;
        memberData.Id = id;
        var member = await memberRepository.Update(memberData);
        return member;
    }
}
