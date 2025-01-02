using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MinimalApiEndpointDiscovery.Configurations.OpenApi;

public class ConfigureSwaggerGenOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
        {
            OpenApiInfo openApiInfo = new()
            {
                Title = $"Template Minimal Api Endpoint Discovery {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
            };
            
            options.SwaggerDoc(description.GroupName, openApiInfo);
        }
    }
    public void Configure(string? name, SwaggerGenOptions options)
    {
        Configure(options);
    }
}