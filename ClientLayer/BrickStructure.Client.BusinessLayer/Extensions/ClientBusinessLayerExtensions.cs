namespace Microsoft.Extensions.DependencyInjection
{
    public static class ClientBusinessLayerExtensions
    {
        public static IServiceCollection RegisterClientManagers(this IServiceCollection services)
        {
            var assembly = typeof(ClientBusinessLayerExtensions).Assembly;
            return services.RegisterManagersFromAssembly(assembly);
        }
    }
}
