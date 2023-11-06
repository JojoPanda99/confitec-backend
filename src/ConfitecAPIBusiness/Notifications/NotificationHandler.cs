using ConfitecAPIBusiness.Interfaces;

namespace ConfitecAPIBusiness.Notifications;

public class NotificationHandler : INotificationHandler
{
    private readonly List<Notification> _notifications;

    public NotificationHandler(List<Notification> notifications)
    {
        _notifications = notifications;
    }

    public void Handler(Notification notification)
    {
        _notifications.Add(notification);
    }

    public bool HasNotification()
    {
        return _notifications.Any();
    }

    public IEnumerable<Notification> GetNotifications()
    {
        return _notifications;
    }
}