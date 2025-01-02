using System.Reflection;
using MinimalApiEndpointDiscovery.Configurations;
using WepApi.Configurations;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddApiGlobalConfiguration();
builder.ConfigureVersioning();
builder.AddSwaggerConfiguration();
builder.AddEndpointDiscovery(Assembly.GetExecutingAssembly());
builder.AddRegisterDependencies();

WebApplication app = builder.Build();
app.UseApiGlobalConfiguration();
app.UseVersioning();
app.UseSwaggerConfiguration();
app.Run();