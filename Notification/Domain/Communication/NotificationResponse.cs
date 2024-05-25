using MindWell_NotificationService.Shared.Domain.Services.Communication;

namespace MindWell_NotificationService.Notification.Domain.Communication;

public class NotificationResponse : BaseResponse<Models.Notification>
{
    public NotificationResponse(string message) : base(message)
    {
    }

    public NotificationResponse(Models.Notification resource) : base(resource)
    {
    }
}