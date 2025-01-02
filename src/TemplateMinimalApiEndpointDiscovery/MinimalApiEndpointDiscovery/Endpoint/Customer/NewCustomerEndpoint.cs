namespace MinimalApiEndpointDiscovery.Endpoint.Customer;

public class NewCustomerEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("customer", async (CancellationToken cancellationToken) =>
           {
               await Task.Delay(5000, cancellationToken);
               return "Success - Endpoint Version 1";
           }).MapToApiVersion(1)
           .WithTags("Customer");
        
        app.MapPost("customer", async (CancellationToken cancellationToken) =>
           {
               await Task.Delay(5000, cancellationToken);
               return "Success - Endpoint Version 2";
           }).MapToApiVersion(2)
           .WithTags("Customer");
    }
}