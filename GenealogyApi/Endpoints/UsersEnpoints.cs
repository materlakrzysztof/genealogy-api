using Genealogy.Domain.Services;
using GenealogyApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GenealogyApi.Endpoints;

internal static class UsersEnpoint
{
    private const string SectionTitle = "Users";

    internal static WebApplication AddUserEndpoint(this WebApplication app)
    {

        var group = app.MapGroup("users");


        group.MapGet("/", async ([FromServices] IUserService userService) =>
        {
         
            var users = await userService.GetAllUsers();
            return Results.Ok(users);
        })

        .WithName("users")
        .WithDescription("returns all users")
        .WithTags(SectionTitle)
        .RequireAuthorization();

        return app;

    }
}