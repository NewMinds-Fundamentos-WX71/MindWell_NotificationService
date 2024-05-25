using AutoMapper;
using MindWell_NotificationService.Notification.Resources.POST;

namespace MindWell_NotificationService.Notification.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveNotificationResource, Domain.Models.Notification>();
    }
}