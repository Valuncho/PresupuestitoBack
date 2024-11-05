using System.Reflection;

namespace PresupuestitoBack.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServicesAndRepositories(this IServiceCollection services, Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                var interfaces = type.GetInterfaces();
                foreach (var interfaceType in interfaces)
                {                    
                    if (interfaceType.Name.EndsWith("Service") || interfaceType.Name.EndsWith("Repository"))
                    {
                        services.AddScoped(interfaceType, type);
                    }
                }
            }
        }
    }
}

