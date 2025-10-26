using Business.Abstractions;
using Business.Entities;
using Resources.Abstractions;
using Resources.Entities;
using Resources;
using Resources.DataContexts;
using Microsoft.EntityFrameworkCore;
using Cross.Entities;
using Business;
using Resources.Mocks;

namespace API
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration, bool production)
        {
            services.AddAutoMapper(
                CrossAssembly.GetAssembly(),
                ApiAssembly.GetAssembly(),
                BusinessAssembly.GetAssembly(), 
                ResourcesAssembly.GetAssembly());

            if(production)
                services.AddResourceDependenciesProd(configuration);
            else
                services.AddResourceDependenciesDev(configuration);

            services.AddBusinessDependencies();
        }

        private static void AddResourceDependenciesDev(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RadiosDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Radios"),
                    b => b.MigrationsAssembly(typeof(RadiosDbContext).Assembly.FullName)), ServiceLifetime.Singleton);


            services.AddSingleton<IArduinoResourceAccess, ArduinoMockAccess>();
            services.AddTransient<IArduinoInstructionsResourceAccess, ArduinoInstructionsResourceAccess>();
            services.AddSingleton<IRadiosResourceAccess, RadiosResourceAccess>();
            services.AddSingleton<IVlcResourceAccess, VlcResourceAccess>();
        }

        private static void AddResourceDependenciesProd(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RadiosDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Radios"),
                    b => b.MigrationsAssembly(typeof(RadiosDbContext).Assembly.FullName)), ServiceLifetime.Singleton);


            services.AddSingleton<IArduinoResourceAccess, ArduinoNanoResourceAccess>();
            services.AddTransient<IArduinoInstructionsResourceAccess, ArduinoInstructionsResourceAccess>();
            services.AddSingleton<IRadiosResourceAccess, RadiosResourceAccess>();
            services.AddSingleton<IVlcResourceAccess, VlcResourceAccess>();
        }

        private static void AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ICaseBusiness, CaseBusiness>();
            services.AddSingleton<IPlayerBusiness, PlayerBusiness>();
        }
    }
}
