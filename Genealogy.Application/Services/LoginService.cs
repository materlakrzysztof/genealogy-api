
using Genealogy.Domain.Repository;
using Genealogy.Domain.Services;

namespace Genealogy.Application.Services;

public class LoginService(IUserRepository userRepository, IJwtService jwtService, IPasswordHasher passwordHasher) : ILoginService
{
    public async Task<string> Login(string username, string password)
    {
        var user = await userRepository.GetUserByUsername(username);
        if (user != null)
        {
            if (passwordHasher.VerifyPassword(user.PasswordHash, password))
            {
                return jwtService.GenerateToken(user);
            }
        }

        return string.Empty;
    }
}
