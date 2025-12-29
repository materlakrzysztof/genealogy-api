using Genealogy.Domain.Entity;
using Genealogy.Domain.Services;
using GenealogyApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GenealogyApi.Endpoints;

internal static class MembersEnpoint
{
    private const string SectionTitle = "members";


    private static FamilyMemberDetails MapToDetails(MemberRequest request)
    {
        var member = new FamilyMemberDetails
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            MaidenName = request.MaidenName,
            Gender = request.Gender,
            BirthDate = request.BirthDate,
            BirthPlace = request.BirthPlace,
            DeathDate = request.DeathDate,
            DeathPlace = request.DeathPlace,
            Notes = request.Notes
        };
        return member;
    }

    internal static WebApplication AddFamilyMembersEndpoint(this WebApplication app)
    {

        var group = app.MapGroup("members");

        group.MapPost("", async ([FromBody] MemberRequest request, [FromServices] IFamilyMemberService service) =>
        {
            var details = MapToDetails(request);
            var member = await service.CreateNew(details);
            return Results.Ok(member);
        })

       .WithName("members create")
       .WithDescription("create family member")
       .WithTags(SectionTitle)
       .RequireAuthorization();

        group.MapPatch("{id:int}", async (int id, [FromBody] MemberRequest request, [FromServices] IFamilyMemberService service) =>
        {
            var details = MapToDetails(request);
            var member = await service.Update(id, details);
            return Results.Ok(member);
        })

        .WithName("member update")
        .WithDescription("create family member")
        .WithTags(SectionTitle)
        .RequireAuthorization();

        group.MapGet("", async ([FromQuery] string? term, [FromServices] IFamilyMemberService service) =>
        {

            var users = await service.GetMembers(term);
            return Results.Ok(users);
        })

       .WithName("members")
       .WithDescription("returns members")
       .WithTags(SectionTitle)
       .RequireAuthorization();

        group.MapGet("{id:int}", async (int id, [FromServices] IFamilyMemberService service) =>
        {
            var member = await service.Get(id);
            return Results.Ok(member);
        })

        .WithName("member get")
        .WithDescription("get family member")
        .WithTags(SectionTitle);

        group.MapDelete("{id:int}", async (int id, [FromServices] IFamilyMemberService service) =>
        {
            var member = await service.Remove(id);
            if (member != null)
            {
                return Results.Ok(member);
            }
            return Results.BadRequest();
        })

        .WithName("member delete")
        .WithDescription("delete family member")
        .WithTags(SectionTitle)
       .RequireAuthorization();

        return app;

    }
}