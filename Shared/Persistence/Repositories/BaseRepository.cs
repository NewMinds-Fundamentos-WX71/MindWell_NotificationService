using MindWell_NotificationService.Shared.Persistence.Context;

namespace MindWell_NotificationService.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}