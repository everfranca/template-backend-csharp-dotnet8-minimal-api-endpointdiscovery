using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MinimalApiEndpointDiscovery.Endpoint;

namespace MinimalApiEndpointDiscovery.Configurations;

public static class EndpointDiscovery
{
    public static void AddEndpointDiscovery(this WebApplicationBuilder builder,
                                            Assembly assembly)
    {
        ServiceDescriptor[] endpointServiceDescriptors = assembly.DefinedTypes.Where(type => type is {IsAbstract: false, IsInterface: false} && 
                                                                                             type.IsAssignableTo(typeof(IEndpoint)))
                                                                              .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
                                                                              .ToArray();
        
        builder.Services.TryAddEnumerable(endpointServiceDescriptors);
    }

    public static void ConfigureVersioning(this WebApplication app)
    {
    }

    public static void MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        IEnumerable<IEndpoint> endpoints = app.Services.GetServices<IEndpoint>();
        
        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }
    }
}