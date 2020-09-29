using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.NotificationHubs;

namespace SIO.Infrastructure.Azure.Tests.Stubs
{
    public class FakeNotificationHubClient : INotificationHubClient
    {
        private bool _throwException;

        public FakeNotificationHubClient(bool throwException)
        {
            _throwException = throwException;
        }

        public bool EnableTestSend => throw new NotImplementedException();

        public Task CancelNotificationAsync(string scheduledNotificationId)
        {
            throw new NotImplementedException();
        }

        public Task CancelNotificationAsync(string scheduledNotificationId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AdmRegistrationDescription> CreateAdmNativeRegistrationAsync(string admRegistrationId)
        {
            throw new NotImplementedException();
        }

        public Task<AdmRegistrationDescription> CreateAdmNativeRegistrationAsync(string admRegistrationId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AdmRegistrationDescription> CreateAdmNativeRegistrationAsync(string admRegistrationId, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task<AdmRegistrationDescription> CreateAdmNativeRegistrationAsync(string admRegistrationId, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AdmTemplateRegistrationDescription> CreateAdmTemplateRegistrationAsync(string admRegistrationId, string jsonPayload)
        {
            throw new NotImplementedException();
        }

        public Task<AdmTemplateRegistrationDescription> CreateAdmTemplateRegistrationAsync(string admRegistrationId, string jsonPayload, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AdmTemplateRegistrationDescription> CreateAdmTemplateRegistrationAsync(string admRegistrationId, string jsonPayload, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task<AdmTemplateRegistrationDescription> CreateAdmTemplateRegistrationAsync(string admRegistrationId, string jsonPayload, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AppleRegistrationDescription> CreateAppleNativeRegistrationAsync(string deviceToken)
        {
            throw new NotImplementedException();
        }

        public Task<AppleRegistrationDescription> CreateAppleNativeRegistrationAsync(string deviceToken, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AppleRegistrationDescription> CreateAppleNativeRegistrationAsync(string deviceToken, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task<AppleRegistrationDescription> CreateAppleNativeRegistrationAsync(string deviceToken, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AppleTemplateRegistrationDescription> CreateAppleTemplateRegistrationAsync(string deviceToken, string jsonPayload)
        {
            throw new NotImplementedException();
        }

        public Task<AppleTemplateRegistrationDescription> CreateAppleTemplateRegistrationAsync(string deviceToken, string jsonPayload, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AppleTemplateRegistrationDescription> CreateAppleTemplateRegistrationAsync(string deviceToken, string jsonPayload, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task<AppleTemplateRegistrationDescription> CreateAppleTemplateRegistrationAsync(string deviceToken, string jsonPayload, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BaiduRegistrationDescription> CreateBaiduNativeRegistrationAsync(string userId, string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<BaiduRegistrationDescription> CreateBaiduNativeRegistrationAsync(string userId, string channelId, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task<BaiduTemplateRegistrationDescription> CreateBaiduTemplateRegistrationAsync(string userId, string channelId, string jsonPayload)
        {
            throw new NotImplementedException();
        }

        public Task<BaiduTemplateRegistrationDescription> CreateBaiduTemplateRegistrationAsync(string userId, string channelId, string jsonPayload, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task<FcmRegistrationDescription> CreateFcmNativeRegistrationAsync(string fcmRegistrationId)
        {
            throw new NotImplementedException();
        }

        public Task<FcmRegistrationDescription> CreateFcmNativeRegistrationAsync(string fcmRegistrationId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<FcmRegistrationDescription> CreateFcmNativeRegistrationAsync(string fcmRegistrationId, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task<FcmRegistrationDescription> CreateFcmNativeRegistrationAsync(string fcmRegistrationId, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<FcmTemplateRegistrationDescription> CreateFcmTemplateRegistrationAsync(string fcmRegistrationId, string jsonPayload)
        {
            throw new NotImplementedException();
        }

        public Task<FcmTemplateRegistrationDescription> CreateFcmTemplateRegistrationAsync(string fcmRegistrationId, string jsonPayload, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<FcmTemplateRegistrationDescription> CreateFcmTemplateRegistrationAsync(string fcmRegistrationId, string jsonPayload, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task<FcmTemplateRegistrationDescription> CreateFcmTemplateRegistrationAsync(string fcmRegistrationId, string jsonPayload, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<MpnsRegistrationDescription> CreateMpnsNativeRegistrationAsync(string channelUri)
        {
            throw new NotImplementedException();
        }

        public Task<MpnsRegistrationDescription> CreateMpnsNativeRegistrationAsync(string channelUri, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task<MpnsTemplateRegistrationDescription> CreateMpnsTemplateRegistrationAsync(string channelUri, string xmlTemplate)
        {
            throw new NotImplementedException();
        }

        public Task<MpnsTemplateRegistrationDescription> CreateMpnsTemplateRegistrationAsync(string channelUri, string xmlTemplate, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public void CreateOrUpdateInstallation(Installation installation)
        {
            throw new NotImplementedException();
        }

        public Task CreateOrUpdateInstallationAsync(Installation installation)
        {
            throw new NotImplementedException();
        }

        public Task CreateOrUpdateInstallationAsync(Installation installation, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<T> CreateOrUpdateRegistrationAsync<T>(T registration) where T : RegistrationDescription
        {
            throw new NotImplementedException();
        }

        public Task<T> CreateOrUpdateRegistrationAsync<T>(T registration, CancellationToken cancellationToken) where T : RegistrationDescription
        {
            throw new NotImplementedException();
        }

        public Task<T> CreateRegistrationAsync<T>(T registration) where T : RegistrationDescription
        {
            throw new NotImplementedException();
        }

        public Task<T> CreateRegistrationAsync<T>(T registration, CancellationToken cancellationToken) where T : RegistrationDescription
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateRegistrationIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateRegistrationIdAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<WindowsRegistrationDescription> CreateWindowsNativeRegistrationAsync(string channelUri)
        {
            throw new NotImplementedException();
        }

        public Task<WindowsRegistrationDescription> CreateWindowsNativeRegistrationAsync(string channelUri, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<WindowsRegistrationDescription> CreateWindowsNativeRegistrationAsync(string channelUri, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task<WindowsRegistrationDescription> CreateWindowsNativeRegistrationAsync(string channelUri, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<WindowsTemplateRegistrationDescription> CreateWindowsTemplateRegistrationAsync(string channelUri, string xmlTemplate)
        {
            throw new NotImplementedException();
        }

        public Task<WindowsTemplateRegistrationDescription> CreateWindowsTemplateRegistrationAsync(string channelUri, string xmlTemplate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<WindowsTemplateRegistrationDescription> CreateWindowsTemplateRegistrationAsync(string channelUri, string xmlTemplate, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task<WindowsTemplateRegistrationDescription> CreateWindowsTemplateRegistrationAsync(string channelUri, string xmlTemplate, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void DeleteInstallation(string installationId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteInstallationAsync(string installationId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteInstallationAsync(string installationId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRegistrationAsync(RegistrationDescription registration)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRegistrationAsync(RegistrationDescription registration, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRegistrationAsync(string registrationId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRegistrationAsync(string registrationId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRegistrationAsync(string registrationId, string etag)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRegistrationAsync(string registrationId, string etag, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRegistrationsByChannelAsync(string pnsHandle)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRegistrationsByChannelAsync(string pnsHandle, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionQueryResult<RegistrationDescription>> GetAllRegistrationsAsync(int top)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionQueryResult<RegistrationDescription>> GetAllRegistrationsAsync(int top, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionQueryResult<RegistrationDescription>> GetAllRegistrationsAsync(string continuationToken, int top)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionQueryResult<RegistrationDescription>> GetAllRegistrationsAsync(string continuationToken, int top, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Uri GetBaseUri()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> GetFeedbackContainerUriAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> GetFeedbackContainerUriAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Installation GetInstallation(string installationId)
        {
            throw new NotImplementedException();
        }

        public Task<Installation> GetInstallationAsync(string installationId)
        {
            throw new NotImplementedException();
        }

        public Task<Installation> GetInstallationAsync(string installationId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationHubJob> GetNotificationHubJobAsync(string jobId)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationHubJob> GetNotificationHubJobAsync(string jobId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NotificationHubJob>> GetNotificationHubJobsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NotificationHubJob>> GetNotificationHubJobsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDetails> GetNotificationOutcomeDetailsAsync(string notificationId)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDetails> GetNotificationOutcomeDetailsAsync(string notificationId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TRegistrationDescription> GetRegistrationAsync<TRegistrationDescription>(string registrationId) where TRegistrationDescription : RegistrationDescription
        {
            throw new NotImplementedException();
        }

        public Task<TRegistrationDescription> GetRegistrationAsync<TRegistrationDescription>(string registrationId, CancellationToken cancellationToken) where TRegistrationDescription : RegistrationDescription
        {
            throw new NotImplementedException();
        }

        public Task<CollectionQueryResult<RegistrationDescription>> GetRegistrationsByChannelAsync(string pnsHandle, int top)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionQueryResult<RegistrationDescription>> GetRegistrationsByChannelAsync(string pnsHandle, int top, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionQueryResult<RegistrationDescription>> GetRegistrationsByChannelAsync(string pnsHandle, string continuationToken, int top)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionQueryResult<RegistrationDescription>> GetRegistrationsByChannelAsync(string pnsHandle, string continuationToken, int top, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionQueryResult<RegistrationDescription>> GetRegistrationsByTagAsync(string tag, int top)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionQueryResult<RegistrationDescription>> GetRegistrationsByTagAsync(string tag, int top, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionQueryResult<RegistrationDescription>> GetRegistrationsByTagAsync(string tag, string continuationToken, int top)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionQueryResult<RegistrationDescription>> GetRegistrationsByTagAsync(string tag, string continuationToken, int top, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool InstallationExists(string installationId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InstallationExistsAsync(string installationId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InstallationExistsAsync(string installationId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void PatchInstallation(string installationId, IList<PartialUpdateOperation> operations)
        {
            throw new NotImplementedException();
        }

        public Task PatchInstallationAsync(string installationId, IList<PartialUpdateOperation> operations)
        {
            throw new NotImplementedException();
        }

        public Task PatchInstallationAsync(string installationId, IList<PartialUpdateOperation> operations, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegistrationExistsAsync(string registrationId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegistrationExistsAsync(string registrationId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ScheduledNotification> ScheduleNotificationAsync(Notification notification, DateTimeOffset scheduledTime)
        {
            throw new NotImplementedException();
        }

        public Task<ScheduledNotification> ScheduleNotificationAsync(Notification notification, DateTimeOffset scheduledTime, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ScheduledNotification> ScheduleNotificationAsync(Notification notification, DateTimeOffset scheduledTime, IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public Task<ScheduledNotification> ScheduleNotificationAsync(Notification notification, DateTimeOffset scheduledTime, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ScheduledNotification> ScheduleNotificationAsync(Notification notification, DateTimeOffset scheduledTime, string tagExpression)
        {
            throw new NotImplementedException();
        }

        public Task<ScheduledNotification> ScheduleNotificationAsync(Notification notification, DateTimeOffset scheduledTime, string tagExpression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationOutcome> SendAdmNativeNotificationAsync(string jsonPayload)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendAdmNativeNotificationAsync(string jsonPayload, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendAdmNativeNotificationAsync(string jsonPayload, IEnumerable<string> tags)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendAdmNativeNotificationAsync(string jsonPayload, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendAdmNativeNotificationAsync(string jsonPayload, string tagExpression)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendAdmNativeNotificationAsync(string jsonPayload, string tagExpression, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendAppleNativeNotificationAsync(string jsonPayload)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendAppleNativeNotificationAsync(string jsonPayload, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendAppleNativeNotificationAsync(string jsonPayload, IEnumerable<string> tags)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendAppleNativeNotificationAsync(string jsonPayload, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendAppleNativeNotificationAsync(string jsonPayload, string tagExpression)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendAppleNativeNotificationAsync(string jsonPayload, string tagExpression, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendBaiduNativeNotificationAsync(string message)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendBaiduNativeNotificationAsync(string message, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendBaiduNativeNotificationAsync(string message, IEnumerable<string> tags)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendBaiduNativeNotificationAsync(string message, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendBaiduNativeNotificationAsync(string message, string tagExpression)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendBaiduNativeNotificationAsync(string message, string tagExpression, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendDirectNotificationAsync(Notification notification, IList<string> deviceHandles)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendDirectNotificationAsync(Notification notification, IList<string> deviceHandles, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendDirectNotificationAsync(Notification notification, string deviceHandle)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendDirectNotificationAsync(Notification notification, string deviceHandle, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendFcmNativeNotificationAsync(string jsonPayload)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendFcmNativeNotificationAsync(string jsonPayload, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendFcmNativeNotificationAsync(string jsonPayload, IEnumerable<string> tags)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendFcmNativeNotificationAsync(string jsonPayload, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendFcmNativeNotificationAsync(string jsonPayload, string tagExpression)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendFcmNativeNotificationAsync(string jsonPayload, string tagExpression, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendMpnsNativeNotificationAsync(string nativePayload)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendMpnsNativeNotificationAsync(string nativePayload, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendMpnsNativeNotificationAsync(string nativePayload, IEnumerable<string> tags)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendMpnsNativeNotificationAsync(string nativePayload, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendMpnsNativeNotificationAsync(string nativePayload, string tagExpression)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendMpnsNativeNotificationAsync(string nativePayload, string tagExpression, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendNotificationAsync(Notification notification)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendNotificationAsync(Notification notification, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendNotificationAsync(Notification notification, IEnumerable<string> tags)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendNotificationAsync(Notification notification, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendNotificationAsync(Notification notification, string tagExpression)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendNotificationAsync(Notification notification, string tagExpression, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendTemplateNotificationAsync(IDictionary<string, string> properties)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendTemplateNotificationAsync(IDictionary<string, string> properties, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendTemplateNotificationAsync(IDictionary<string, string> properties, IEnumerable<string> tags)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendTemplateNotificationAsync(IDictionary<string, string> properties, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendTemplateNotificationAsync(IDictionary<string, string> properties, string tagExpression)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendTemplateNotificationAsync(IDictionary<string, string> properties, string tagExpression, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendWindowsNativeNotificationAsync(string windowsNativePayload)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendWindowsNativeNotificationAsync(string windowsNativePayload, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendWindowsNativeNotificationAsync(string windowsNativePayload, IEnumerable<string> tags)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendWindowsNativeNotificationAsync(string windowsNativePayload, IEnumerable<string> tags, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendWindowsNativeNotificationAsync(string windowsNativePayload, string tagExpression)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationOutcome> SendWindowsNativeNotificationAsync(string windowsNativePayload, string tagExpression, CancellationToken cancellationToken)
        {
            if (_throwException)
                throw new Exception();

            return Task.FromResult(new NotificationOutcome());
        }

        public Task<NotificationHubJob> SubmitNotificationHubJobAsync(NotificationHubJob job)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationHubJob> SubmitNotificationHubJobAsync(NotificationHubJob job, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateRegistrationAsync<T>(T registration) where T : RegistrationDescription
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateRegistrationAsync<T>(T registration, CancellationToken cancellationToken) where T : RegistrationDescription
        {
            throw new NotImplementedException();
        }
    }
}
