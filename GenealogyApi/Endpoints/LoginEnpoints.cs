using Genealogy.Domain.Services;
using GenealogyApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GenealogyApi.Endpoints;

internal static class LoginEndpoint
{
    private const string SectionTitle = "Login";

    internal static WebApplication AddLoginEndpoint(this WebApplication app)
    {

        app.MapPost("/login", async ([FromBody] LoginRequest request, [FromServices] ILoginService loginService) =>
        {
            if (string.IsNullOrEmpty(request?.Username) || string.IsNullOrEmpty(request?.Password))
            {
                return Results.BadRequest("Request cannot be null or empty.");
            }
            var token = await loginService.Login(request.Username, request.Password);

            if (string.IsNullOrEmpty(token))
            {

                return Results.Unauthorized();
            }

            return Results.Ok(new { Token = token });
        })

        .WithName("login")
        .WithDescription("returns Jwt token")
        .WithTags(SectionTitle);

        return app;

    }
}