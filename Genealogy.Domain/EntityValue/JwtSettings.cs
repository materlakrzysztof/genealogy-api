namespace Genealogy.Domain.EntityValue;

public record JwtSettings(string Issuer, string Audience, string SecretKey, int ExpiryMinutes)
{
}
