using Genealogy.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenealogyApi.Endpoints;

internal static class RootEndpoint
{
    private const string SectionTitle = "Root";

    internal static WebApplication AddRootEndpoint(this WebApplication app)
    {

        app.MapGet("/health", () =>
        {

            return Results.Ok();
        })
       .WithName("healthcheck")
       .WithDescription("Returns ok")
       .WithSummary("Returns ok")
       .WithTags(SectionTitle); ;

        app.MapGet("/root", () =>
        {
            var machineName = Environment.MachineName;
            var dateTime = DateTime.UtcNow;
            var version = app.Configuration["Version"]; // Retrieve version from appsettings.json
            var deploymentDate = app.Configuration["DEPLOYMENT_TIMESTAMP"]; // Retrieve build timestamp from appsettings.json

            // Create a dictionary for the response
            var response = new Dictionary<string, object>
            {
                { "Application", "Genealogy API" },
                { "Machine", machineName },
                { "Now", dateTime }
            };

            // Add the version if it exists
            if (!string.IsNullOrEmpty(version))
            {
                response["Version"] = version; // Add the version only if it exists
            }

            if (!string.IsNullOrWhiteSpace(deploymentDate))
            {
                response["DeploymentDate"] = deploymentDate; // Add the version only if it exists
            }

            return Results.Ok(response);
        })

        .WithName("instance information")
        .WithDescription("\"Returns the application name, machine name, date and time (UTC) and app version of currently running instance")
        .WithSummary("Returns current instances information")
        .WithTags(SectionTitle);



        app.MapGet("/hash", ([FromQuery] string password, [FromServices] IPasswordHasher passwordHasher) =>
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                return Results.BadRequest("Password cannot be null or empty.");
            }

            return Results.Ok(passwordHasher.HashPassword(
                password));
        })
        .WithName("password hasher")
        .WithDescription("Returns hash of the password")
        .WithSummary("Returns hash of the password")
        .WithTags(SectionTitle); ;

        return app;

    }
}