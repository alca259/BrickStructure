using BrickStructure.Data.Agents;
using BrickStructure.Data.Contracts;
using BrickStructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection RegisterApplicationContext(this IServiceCollection services, IConfiguration config, string connString)
        {
            return services.AddDbContext<ApplicationRepository>(options => options.UseSqlServer(config.GetConnectionString(connString)));
        }

        public static IServiceCollection RegisterDefaultAgents(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAgent<>), typeof(DefaultAgent<>));

            var assembly = typeof(DefaultAgent<>).Assembly;
            RegisterAgents(services, assembly);
            return services;
        }

        public static IServiceCollection RegisterAgentsFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            RegisterAgents(services, assembly);
            return services;
        }

        private static void RegisterAgents(IServiceCollection services, Assembly assembly)
        {
            var typesToRegister = assembly.GetTypes().Where(w => w.GetInterfaces()
                .Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IAgent<>))).ToList();

            foreach (var type in typesToRegister)
            {
                services.AddScoped(type);
            }

            typesToRegister.Clear();
        }
    }
}
