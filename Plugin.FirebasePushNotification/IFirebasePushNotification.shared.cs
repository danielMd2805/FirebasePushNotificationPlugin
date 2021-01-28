using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plugin.FirebasePushNotification
{
    public enum FirebasePushNotificationErrorType
    {
        Unknown,
        PermissionDenied,
        RegistrationFailed,
        UnregistrationFailed
    }

    public delegate void FirebasePushNotificationDataEventHandler(object source, FirebasePushNotificationDataEventArgs e);

    public delegate void FirebasePushNotificationErrorEventHandler(object source, FirebasePushNotificationErrorEventArgs e);

    public delegate void FirebasePushNotificationResponseEventHandler(object source, FirebasePushNotificationResponseEventArgs e);

    public delegate void FirebasePushNotificationTokenEventHandler(object source, FirebasePushNotificationTokenEventArgs e);

    /// <summary>
    /// Interface for FirebasePushNotification
    /// </summary>
    public interface IFirebasePushNotification
    {
        #region Public Properties

        /// <summary>
        /// Notification handler to receive, customize notification feedback and provide user actions
        /// </summary>
        IPushNotificationHandler NotificationHandler { get; set; }

        /// <summary>
        /// Get all subscribed topics
        /// </summary>
        string[] SubscribedTopics { get; }

        /// <summary>
        /// Push notification token
        /// </summary>
        string Token { get; }

        #endregion Public Properties

        #region Public Events

        /// <summary>
        /// Event triggered when a notification is opened by tapping an action
        /// </summary>
        event FirebasePushNotificationResponseEventHandler OnNotificationAction;

        /// <summary>
        /// Event triggered when a notification is deleted
        /// </summary>
        event FirebasePushNotificationDataEventHandler OnNotificationDeleted;

        /// <summary>
        /// Event triggered when there's an error
        /// </summary>
        event FirebasePushNotificationErrorEventHandler OnNotificationError;

        /// <summary>
        /// Event triggered when a notification is opened
        /// </summary>
        event FirebasePushNotificationResponseEventHandler OnNotificationOpened;

        /// <summary>
        /// Event triggered when a notification is received
        /// </summary>
        event FirebasePushNotificationDataEventHandler OnNotificationReceived;

        /// <summary>
        /// Event triggered when token is refreshed
        /// </summary>
        event FirebasePushNotificationTokenEventHandler OnTokenRefresh;

        #endregion Public Events

        #region Public Methods

        /// <summary>
        /// Clear all notifications
        /// </summary>
        void ClearAllNotifications();

        Task<string> GetTokenAsync();

        /// <summary>
        /// Get all user notification categories
        /// </summary>
        NotificationUserCategory[] GetUserNotificationCategories();

        /// <summary>
        /// Register push notifications on demand
        /// </summary>
        /// <returns></returns>
        void RegisterForPushNotifications();

        /// <summary>
        /// Remove specific id notification
        /// </summary>
        void RemoveNotification(int id);

        /// <summary>
        /// Remove specific id and tag notification
        /// </summary>
        void RemoveNotification(string tag, int id);

        /// <summary>
        /// Send device group message
        /// </summary>
        void SendDeviceGroupMessage(IDictionary<string, string> parameters, string groupKey, string messageId, int timeOfLive);

        /// <summary>
        /// Subscribe to multiple topics
        /// </summary>
        void Subscribe(string[] topics);

        /// <summary>
        /// Subscribe to one topic
        /// </summary>
        void Subscribe(string topic);

        /// <summary>
        /// Unregister push notifications on demand
        /// </summary>
        /// <returns></returns>
        void UnregisterForPushNotifications();

        /// <summary>
        /// Unsubscribe to one topic
        /// </summary>
        void Unsubscribe(string topic);

        /// <summary>
        /// Unsubscribe to multiple topics
        /// </summary>
        void Unsubscribe(string[] topics);

        /// <summary>
        /// Unsubscribe all topics
        /// </summary>
        void UnsubscribeAll();

        #endregion Public Methods
    }

    public class FirebasePushNotificationDataEventArgs : EventArgs
    {
        #region Public Properties

        public IDictionary<string, object> Data { get; }

        #endregion Public Properties

        #region Public Constructors

        public FirebasePushNotificationDataEventArgs(IDictionary<string, object> data)
        {
            Data = data;
        }

        #endregion Public Constructors
    }

    public class FirebasePushNotificationErrorEventArgs : EventArgs
    {
        #region Public Properties

        public string Message { get; }

        #endregion Public Properties

        #region Public Fields

        public FirebasePushNotificationErrorType Type;

        #endregion Public Fields

        #region Public Constructors

        public FirebasePushNotificationErrorEventArgs(FirebasePushNotificationErrorType type, string message)
        {
            Type = type;
            Message = message;
        }

        #endregion Public Constructors
    }

    public class FirebasePushNotificationResponseEventArgs : EventArgs
    {
        #region Public Properties

        public IDictionary<string, object> Data { get; }
        public string Identifier { get; }
        public NotificationCategoryType Type { get; }

        #endregion Public Properties

        #region Public Constructors

        public FirebasePushNotificationResponseEventArgs(IDictionary<string, object> data, string identifier = "", NotificationCategoryType type = NotificationCategoryType.Default)
        {
            Identifier = identifier;
            Data = data;
            Type = type;
        }

        #endregion Public Constructors
    }

    public class FirebasePushNotificationTokenEventArgs : EventArgs
    {
        #region Public Properties

        public string Token { get; }

        #endregion Public Properties

        #region Public Constructors

        public FirebasePushNotificationTokenEventArgs(string token)
        {
            Token = token;
        }

        #endregion Public Constructors
    }
}
