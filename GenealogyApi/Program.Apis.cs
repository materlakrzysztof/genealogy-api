using GenealogyApi.Endpoints;


public static partial class WebApplicationBuilderExtensions
{
    internal static WebApplication AddMinimalApis(this WebApplication app) => app
        .AddRootEndpoint()
        .AddLoginEndpoint()
        .AddUserEndpoint()
        .AddFamilyMembersEndpoint();
}