namespace MinimalApiEndpointDiscovery.Configurations;

public static class ApiConfiguration
{
    public static void AddApiGlobalConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
    }
    
    public static void UseApiGlobalConfiguration(this WebApplication app)
    {
        app.UseHttpsRedirection();
    }
}