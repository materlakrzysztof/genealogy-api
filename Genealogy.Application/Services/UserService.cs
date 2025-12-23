using Genealogy.Domain.Entity;
using Genealogy.Domain.Repository;
using Genealogy.Domain.Services;

namespace Genealogy.Application.Services;

public class UserService(IUserRepository userRepository, IPasswordHasher passwordHasher): IUserService
{
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var users = await userRepository.GetAllUsers();
        return users;
    }

    public async Task<User> CreateNewUser(string username, string password, Role role)
    {
        return null;
    }


    public async Task SetNewPassword(int userId, string newPassword)
    {
        await userRepository.SetPasswordForUser(userId, passwordHasher.HashPassword(newPassword));
    }


}
