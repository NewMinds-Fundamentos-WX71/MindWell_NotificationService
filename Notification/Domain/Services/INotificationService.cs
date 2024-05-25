using MindWell_NotificationService.Notification.Domain.Communication;

namespace MindWell_NotificationService.Notification.Domain.Services;

public interface INotificationService
{
    Task<IEnumerable<Models.Notification>> ListAsync();
    Task<Models.Notification> GetByIdAsync(int id);
    Task<NotificationResponse> SaveAsync(Models.Notification notification);
    Task<NotificationResponse> UpdateAsync(int id, Models.Notification notification);
    Task<NotificationResponse> DeleteAsync(int id);
}