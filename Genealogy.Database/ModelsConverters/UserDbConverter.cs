using Genealogy.Database.Models;
using Genealogy.Domain.Entity;

namespace Genealogy.Database.ModelsConverters;

internal static class UserDbConverter
{
    public static User ToDomainModel(this UserDb dbModel)
    {
        Role role = (Role)dbModel.Role;
        return new User(
            dbModel.Id,
            dbModel.UserName, dbModel.PasswordHash, dbModel.CreateDate ?? DateTime.UtcNow, dbModel.Active, role);
    }
}
