namespace MindWell_NotificationService.Notification.Domain.Models;

public class Notification
{
    public int Id { get; set; }

    public string text { get; set; }

    public string category { get; set; }
    
    public int User_id { get; set; }

}