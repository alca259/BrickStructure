using BrickStructure.Data.Contracts;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataLayerExtensions
    {
        public static void RegisterAllRepositories(this IServiceCollection services)
        {
            var assembly = typeof(DataLayerExtensions).Assembly;
            var typesToRegister = assembly.GetTypes().Where(w => w.GetInterfaces()
                .Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IRepositoryContext))).ToList();

            foreach (var type in typesToRegister)
            {
                services.AddTransient(type);
            }

            typesToRegister.Clear();
        }

        public static void RegisterAllAgents(this IServiceCollection services)
        {
            var assembly = typeof(DataLayerExtensions).Assembly;
            var typesToRegister = assembly.GetTypes().Where(w => w.GetInterfaces()
                .Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IAgent<>))).ToList();

            foreach (var type in typesToRegister)
            {
                services.AddTransient(type);
            }

            typesToRegister.Clear();
        }
    }
}
