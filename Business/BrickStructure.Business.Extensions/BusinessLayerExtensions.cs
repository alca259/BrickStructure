using BrickStructure.Business.Contracts;
using BrickStructure.Business.Managers;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BusinessLayerExtensions
    {
        public static IServiceCollection RegisterDefaultManagers(this IServiceCollection services)
        {
            services.AddTransient(typeof(IManager<,,>), typeof(DefaultManager<,,>));

            var assembly = typeof(DefaultManager<,,>).Assembly;
            RegisterManagers(services, assembly);
            return services;
        }

        public static IServiceCollection RegisterManagersFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            RegisterManagers(services, assembly);
            return services;
        }

        private static void RegisterManagers(IServiceCollection services, Assembly assembly)
        {
            var typesToRegister = assembly.GetTypes().Where(w => w.GetInterfaces()
                .Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IManager<,,>))).ToList();

            foreach (var type in typesToRegister)
            {
                services.AddTransient(type);
            }

            typesToRegister.Clear();
        }
    }
}
