﻿using System;
using Microsoft.Extensions.DependencyInjection;
using SIO.Infrastructure.Notifications;
using Xunit;

namespace SIO.Infrastructure.Azure.Tests.Notifications.AndroidNotificationProcessor
{
    public abstract class AndroidNotificationProcessorSpecification : AzureNotificationProcessorSpecification, IClassFixture<AzureNotificationProcessorFixture>
    {
        private readonly Lazy<AzureNotificationProcessorFixture> _azureNotificationProcessorFixture;
        protected INotificationProcessor NotificationProcessor => _azureNotificationProcessorFixture.Value;

        protected AndroidNotificationProcessorSpecification(ConfigurationFixture configurationFixture, AzureNotificationProcessorFixture azureNotificationProcessorFixture) : base(configurationFixture)
        {
            _azureNotificationProcessorFixture = new Lazy<AzureNotificationProcessorFixture>(() =>
            {
                azureNotificationProcessorFixture.Init(_serviceProvider.GetRequiredService<Azure.Notifications.AndroidNotificationProcessor>());
                return azureNotificationProcessorFixture;
            });
        }
    }
}
