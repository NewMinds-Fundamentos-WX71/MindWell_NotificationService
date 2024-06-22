using MindWell_NotificationService.Notification.Domain.Communication;
using MindWell_NotificationService.Notification.Domain.Repositories;
using MindWell_NotificationService.Notification.Domain.Services;
using MindWell_NotificationService.Shared.Persistence.Repositories;

namespace MindWell_NotificationService.Notification.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Models.Notification>> ListAsync()
    {
        return await _notificationRepository.ListAsync();
    }

    public async Task<Domain.Models.Notification> GetByIdAsync(int id)
    {
        return await _notificationRepository.FindByIdAsync(id);
    }

    public async Task<IEnumerable<Domain.Models.Notification>> ListAllByUserIdAsync(int userId)
    {
        return await _notificationRepository.FindAllByUserIdAsync(userId);
    }

    public async Task<NotificationResponse> SaveAsync(Domain.Models.Notification notification)
    {
        try
        {
            await _notificationRepository.AddAsync(notification);
            await _unitOfWork.CompleteAsync();
            return new NotificationResponse(notification);
        }
        catch (Exception e)
        {
            return new NotificationResponse($"An error occurred while saving the notification: {e.Message}");
        }
    }

    public async Task<NotificationResponse> UpdateAsync(int id, Domain.Models.Notification notification)
    {
        try
        {
            var existingNotification = await _notificationRepository.FindByIdAsync(id);

            if (existingNotification == null)
                return new NotificationResponse("Notification not found.");

            existingNotification.text = notification.text;
            existingNotification.category = notification.category;

            _notificationRepository.Update(existingNotification);
            await _unitOfWork.CompleteAsync();
            return new NotificationResponse(existingNotification);
        }
        catch (Exception e)
        {
            return new NotificationResponse($"An error occurred while updating the notification: {e.Message}");
        }
    }

    public async Task<NotificationResponse> DeleteAsync(int id)
    {
        try
        {
            var existingNotification = await _notificationRepository.FindByIdAsync(id);

            if (existingNotification == null)
                return new NotificationResponse("Notification not found.");

            _notificationRepository.Remove(existingNotification);
            await _unitOfWork.CompleteAsync();
            return new NotificationResponse(existingNotification);
        }
        catch (Exception e)
        {
            return new NotificationResponse($"An error occurred while deleting the notification: {e.Message}");
        }
    }
}