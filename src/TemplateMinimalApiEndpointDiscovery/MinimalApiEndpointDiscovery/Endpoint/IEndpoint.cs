namespace MinimalApiEndpointDiscovery.Endpoint;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder endpoint);
}