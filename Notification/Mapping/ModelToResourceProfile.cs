using AutoMapper;
using MindWell_NotificationService.Notification.Resources.GET;

namespace MindWell_NotificationService.Notification.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Notification, NotificationResource>();
    }
}