using ConfitecAPIBusiness.Notifications;

namespace ConfitecAPIBusiness.Interfaces;

public interface INotificationHandler
{
    void Handler(Notification notification);
    bool HasNotification();
    IEnumerable<Notification> GetNotifications();
}