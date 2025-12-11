using Genealogy.Database.ModelsConverters;
using Genealogy.Domain.Entity;
using Genealogy.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Genealogy.Database.Repository;

public class UserRepository(GenealogyDbContext genealogyDb) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var userDbModels = await genealogyDb.Users.AsNoTracking().ToListAsync();
        return userDbModels.Select(x => x.ToDomainModel());
    }

    public async Task<User?> GetUserById(int id)
    {
        var userDbModel = await genealogyDb.Users.FirstOrDefaultAsync(x => x.Id == id);
        return userDbModel?.ToDomainModel();
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        var userDbModel = await genealogyDb.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == username);
        return userDbModel?.ToDomainModel();
    }
}
