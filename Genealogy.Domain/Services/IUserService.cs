using Genealogy.Domain.Entity;

namespace Genealogy.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> CreateNewUser(string username, string password, Role role);
    Task SetNewPassword(int userId, string newPassword);
}
