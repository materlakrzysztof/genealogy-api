using Genealogy.Database.Models;
using Genealogy.Domain.Entity;

namespace Genealogy.Database.ModelsConverters;

internal static class FamilyMemberDbConverter
{
    public static FamilyMember ToDomainModel(this FamilyMemberDb dbModel)
    {
        Gender gender = (Gender)dbModel.Gender;
        return new FamilyMember
        {
            Id = dbModel.Id,
            FirstName = dbModel.FirstName,
            LastName = dbModel.LastName,
            Gender = gender,
            MaidenName = dbModel.MaidenName,
            MiddleName = dbModel.MiddleName,
            DateOfBirth = dbModel.DateOfBirth,
            DateOfDeath = dbModel.DateOfDeath,
            PlaceOfDeath = dbModel.PlaceOfDeath,
            PlaceOfBirth = dbModel.PlaceOfBirth,
            Notes = dbModel.Notes,
        };
    }

    public static FamilyMemberDb ToDbModel(this FamilyMember model)
    {
        return new FamilyMemberDb
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Gender = (int)model.Gender,
            MaidenName = model.MaidenName,
            MiddleName = model.MiddleName,
            DateOfBirth = model.DateOfBirth,
            DateOfDeath = model.DateOfDeath,
            PlaceOfDeath = model.PlaceOfDeath,
            PlaceOfBirth = model.PlaceOfBirth,
            Notes = model.Notes,
        };
    }
}
