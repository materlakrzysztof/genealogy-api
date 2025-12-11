using Genealogy.Domain.Entity;

namespace Genealogy.Domain.Repository;

public interface IUserRepository
{
    Task<User?> GetUserByUsername(string username);
    Task<User?> GetUserById(int id);
    Task<IEnumerable<User>> GetAllUsers();
}
