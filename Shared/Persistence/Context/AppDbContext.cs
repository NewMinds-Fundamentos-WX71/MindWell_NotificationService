using Microsoft.EntityFrameworkCore;
using MindWell_NotificationService.Shared.Extension;

namespace MindWell_NotificationService.Shared.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<Notification.Domain.Models.Notification> Notifications { get; set; }
    
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Notification.Domain.Models.Notification>().ToTable("Notifications");
        builder.Entity<Notification.Domain.Models.Notification>().HasKey(X => X.Id);
        builder.Entity<Notification.Domain.Models.Notification>().Property(X => X.text).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Notification.Domain.Models.Notification>().Property(X => X.category).IsRequired();
        builder.Entity<Notification.Domain.Models.Notification>().Property(X => X.User_id).IsRequired();
        
        
        builder.UseSnakeCaseNamingConvention();
    }
}