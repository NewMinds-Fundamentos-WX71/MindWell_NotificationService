namespace MindWell_NotificationService.Notification.Domain.Repositories;

public interface INotificationRepository
{
    Task<IEnumerable<Models.Notification>> ListAsync();
    Task<Models.Notification> FindByIdAsync(int id);
    Task AddAsync(Models.Notification notification);
    void Update(Models.Notification notification);
    void Remove(Models.Notification notification);
}