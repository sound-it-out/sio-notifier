using Microsoft.Extensions.DependencyInjection;
using SIO.Migrations.DbContexts;

namespace SIO.Migrations.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMigrations(this IServiceCollection source)
        {
            source.AddSingleton<ISIONotifierDbContextFactory, SIONotifierDbContextFactory>();

            return source;
        }
    }
}
