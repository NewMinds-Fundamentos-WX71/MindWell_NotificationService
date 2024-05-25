using Microsoft.EntityFrameworkCore;
using MindWell_NotificationService.Notification.Domain.Repositories;
using MindWell_NotificationService.Shared.Persistence.Context;
using MindWell_NotificationService.Shared.Persistence.Repositories;

namespace MindWell_NotificationService.Notification.Persistence.Repositories;

public class NotificationRepository : BaseRepository , INotificationRepository
{
    public NotificationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Models.Notification>> ListAsync()
    {
        return await _context.Notifications.ToListAsync();
    }

    public async Task<Domain.Models.Notification> FindByIdAsync(int id)
    {
        return await _context.Notifications.FindAsync(id);
    }

    public async Task AddAsync(Domain.Models.Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
    }

    public void Update(Domain.Models.Notification notification)
    {
        _context.Update(notification);
    }

    public void Remove(Domain.Models.Notification notification)
    {
        _context.Notifications.Remove(notification);
    }
}