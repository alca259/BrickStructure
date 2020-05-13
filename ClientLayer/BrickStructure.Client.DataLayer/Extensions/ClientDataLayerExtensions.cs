namespace Microsoft.Extensions.DependencyInjection
{
    public static class ClientDataLayerExtensions
    {
        public static IServiceCollection RegisterClientAgents(this IServiceCollection services)
        {
            var assembly = typeof(ClientDataLayerExtensions).Assembly;
            return services.RegisterAgentsFromAssembly(assembly);
        }
    }
}
