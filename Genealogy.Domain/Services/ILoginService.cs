namespace Genealogy.Domain.Services;

public interface ILoginService
{
    Task<string> Login(string username, string password);
}
