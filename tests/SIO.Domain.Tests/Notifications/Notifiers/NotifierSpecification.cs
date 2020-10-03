using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenEventSourcing.Commands;
using OpenEventSourcing.Extensions;
using OpenEventSourcing.Serialization.Json.Extensions;
using SIO.Domain.Extensions;
using SIO.Testing.Abstractions;
using SIO.Testing.Extensions;

namespace SIO.Domain.Tests.Notifications.Notifiers
{
    public abstract class NotifierSpecification : Specification
    {
        protected override void BuildServices(IServiceCollection services)
        {
            services.AddOpenEventSourcing()
                .AddCommands()
                .AddEvents()
                .AddQueries()
                .AddJsonSerializers();

            services.AddDomain();
            services.AddInMemoryDatabase();
            services.AddLogging();
            services.RemoveAll<ICommandDispatcher>();
            services.AddSingleton<ICommandDispatcher, FakeCommandDispatcher>();

            base.BuildServices(services);
        }
    }
}
