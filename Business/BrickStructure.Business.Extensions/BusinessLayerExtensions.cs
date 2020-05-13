using BrickStructure.Business.Contracts;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BusinessLayerExtensions
    {
        public static void RegisterAllManagers(this IServiceCollection services)
        {
            var assembly = typeof(BusinessLayerExtensions).Assembly;
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
