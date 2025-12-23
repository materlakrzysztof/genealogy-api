using Genealogy.Database.Models;
using Genealogy.Database.ModelsConverters;
using Genealogy.Domain.Entity;
using Genealogy.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Genealogy.Database.Repository;

public class MemberRepository(GenealogyDbContext genealogyDb) : IMemberRepository
{
    public async Task<FamilyMember> Create(FamilyMember familyMember)
    {
        var member = await genealogyDb.FamilyMembers.AddAsync(familyMember.ToDbModel());
        await genealogyDb.SaveChangesAsync();
        return member.Entity.ToDomainModel();
    }


    public async Task<FamilyMember> Update(FamilyMember familyMember)
    {
        var member = await genealogyDb.FamilyMembers.FirstOrDefaultAsync(x => x.Id == familyMember.Id);
        var data = familyMember.ToDbModel();
        member.FirstName = data.FirstName;
        member.LastName = data.LastName;
        member.MaidenName = data.MaidenName;
        member.Gender = data.Gender;
        member.MaidenName = data.MaidenName;
        member.MiddleName = data.MiddleName;
        member.DateOfBirth = data.DateOfBirth;
        member.DateOfDeath = data.DateOfDeath;
        member.PlaceOfDeath = data.PlaceOfDeath;
        member.PlaceOfBirth = data.PlaceOfBirth;
        member.Notes = data.Notes;

        //var member = await genealogyDb.FamilyMembers.Update(member);
        await genealogyDb.SaveChangesAsync();
        return member.ToDomainModel();
    }


    //public async Task<IEnumerable<FamilyMember>> GetMembersWithRelationshipsAsync()
    //{
    //    return await _context.FamilyMembers
    //        .Include(fm => fm.RelationshipsAsSource)
    //        .ThenInclude(r => r.TargetMember)
    //        .Include(fm => fm.RelationshipsAsTarget)
    //        .ThenInclude(r => r.SourceMember)
    //        .ToListAsync();
    //}

    //public async Task<FamilyMember?> GetMemberWithRelationshipsAsync(Guid id)
    //{
    //    return await _context.FamilyMembers
    //        .Include(fm => fm.RelationshipsAsSource)
    //        .ThenInclude(r => r.TargetMember)
    //        .Include(fm => fm.RelationshipsAsTarget)
    //        .ThenInclude(r => r.SourceMember)
    //        .FirstOrDefaultAsync(fm => fm.Id == id);
    //}


    public async Task<IEnumerable<FamilyMember>> SearchAsync(string searchTerm, int take = 10, int skip = 0)
    {
        var lowerSearchTerm = searchTerm.ToLower();

        return await genealogyDb.FamilyMembers
            .Where(fm =>
                fm.FirstName.ToLower().Contains(lowerSearchTerm) ||
                fm.LastName.ToLower().Contains(lowerSearchTerm) ||
                (fm.MaidenName != null && fm.MaidenName.ToLower().Contains(lowerSearchTerm)))
            .OrderBy(fm => fm.LastName)
            .ThenBy(fm => fm.FirstName)
            .Take(take)
            .Select(x => x.ToDomainModel())
            .AsNoTracking()
            .ToListAsync();
    }
}
