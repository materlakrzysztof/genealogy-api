using Genealogy.Domain.Entity;
using System.Security.Claims;

namespace Genealogy.Domain.Services;
public interface IJwtService
{
    string GenerateToken(User user);
    ClaimsPrincipal? ValidateToken(string token);
}
