using Asp.Versioning;
using Asp.Versioning.Builder;

namespace MinimalApiEndpointDiscovery.Configurations;

public static class ApiVersionConfiguration
{
    internal static void ConfigureVersioning(this WebApplicationBuilder builder)
    {
        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });
    }

    internal static void UseVersioning(this WebApplication app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
                                         .HasApiVersion(new ApiVersion(1))
                                         .HasApiVersion(new ApiVersion(2))
                                         .ReportApiVersions()
                                         .Build();
        
        RouteGroupBuilder groupBuilder = app.MapGroup("api/v{apiVersion:apiVersion}")
                                            .WithApiVersionSet(apiVersionSet);
        
        app.MapEndpoints(groupBuilder);
        
    }
}