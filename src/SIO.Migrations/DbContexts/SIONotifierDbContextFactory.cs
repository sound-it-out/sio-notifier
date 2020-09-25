using System;
using Microsoft.Extensions.DependencyInjection;

namespace SIO.Migrations.DbContexts
{
    public class SIONotifierDbContextFactory : ISIONotifierDbContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SIONotifierDbContextFactory(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            _serviceProvider = serviceProvider;
        }

        public SIONotifierDbContext Create()
        {
            return _serviceProvider.GetRequiredService<SIONotifierDbContext>();
        }
    }
}
