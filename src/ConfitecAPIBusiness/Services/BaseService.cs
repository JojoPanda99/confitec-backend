using ConfitecAPIBusiness.Interfaces;
using ConfitecAPIBusiness.Models;
using ConfitecAPIBusiness.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace ConfitecAPIBusiness.Services;

public class BaseService
{
    protected readonly INotificationHandler NotificationHandler;

    public BaseService(INotificationHandler notificationHandler)
    {
        NotificationHandler = notificationHandler;
    }

    protected void AddNotification(string message)
    {
        NotificationHandler.Handler(new Notification(message));
    }

    protected void NotifyValidationFailure(List<ValidationFailure> resultErrors)
    {
        foreach (var error in resultErrors)
        {
            NotificationHandler.Handler(new Notification(error.ErrorMessage));
        }
    }

    protected async Task<bool> ValidateAsync<T, TV>(T entity, TV validator)
        where T : BaseEntity where TV : AbstractValidator<T>
    {
        var result = await validator.ValidateAsync(entity);
        if (result.IsValid)
            return true;

        NotifyValidationFailure(result.Errors);
        return false;
    }
}