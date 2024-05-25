namespace MindWell_NotificationService.Shared.Persistence.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}