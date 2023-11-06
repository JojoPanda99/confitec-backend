using ConfitecAPIBusiness.Interfaces;
using ConfitecAPIBusiness.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConfitecAPIApplication.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BaseController : ControllerBase
{
    private readonly INotificationHandler _notificationHandler;

    public BaseController(INotificationHandler notificationHandler)
    {
        _notificationHandler = notificationHandler;
    }

    protected bool HasNotification() => _notificationHandler.HasNotification();

    protected void AddNotification(string message)
    {
        _notificationHandler.Handler(new Notification(message));
    }

    protected IActionResult CustomResponse(object? result = null)
    {
        if (!_notificationHandler.HasNotification())
        {
            return Ok(result);
        }


        return BadRequest(new Dictionary<string, string[]>
        {
            { "messages", _notificationHandler.GetNotifications().Select(m => m.Message).ToArray() }
        });
    }

    protected IActionResult CustomResponse(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);

        foreach (var error in errors)
        {
            AddNotification(error.ErrorMessage);
        }

        return CustomResponse();
    }
}