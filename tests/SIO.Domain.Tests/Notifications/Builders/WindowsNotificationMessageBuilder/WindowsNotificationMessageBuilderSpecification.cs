using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenEventSourcing.Extensions;
using OpenEventSourcing.Serialization.Json.Extensions;
using SIO.Domain.Extensions;
using SIO.Domain.Notifications.Builders;
using SIO.Testing.Abstractions;
using SIO.Testing.Extensions;
using SIO.Testing.Fakes.Notifications.Builders;

namespace SIO.Domain.Tests.Notifications.Builders.WindowsNotificationMessageBuilder
{
    public abstract class WindowsNotificationMessageBuilderSpecification : Specification<string>
    {
        protected IWindowsNotificationMessageBuilder MessageBuilder => _serviceProvider.GetRequiredService<IWindowsNotificationMessageBuilder>();

        protected override void BuildServices(IServiceCollection services)
        {
            services.AddDomain()
                .AddInMemoryDatabase()
                .AddOpenEventSourcing()
                .AddEvents()
                .AddJsonSerializers();

            services.RemoveAll<IRazorViewBuilder>();
            services.AddSingleton<IRazorViewBuilder, FakeRazorViewBuilder>();
            base.BuildServices(services);
        }
    }
}
