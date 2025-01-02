using Asp.Versioning.ApiExplorer;
using MinimalApiEndpointDiscovery.Configurations.OpenApi;

// ReSharper disable All

namespace WepApi.Configurations;

public static class SwaggerConfiguration
{
    internal static void AddSwaggerConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();
    }

    internal static void UseSwaggerConfiguration(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
            return;

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            IReadOnlyList<ApiVersionDescription> descriptions = app.DescribeApiVersions();

            foreach (ApiVersionDescription description in descriptions)
            {
                string url = $"/swagger/{description.GroupName}/swagger.json";
                string name = description.GroupName.ToUpperInvariant();
                
                options.SwaggerEndpoint(url, name);
            }
        });
    }
}