using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MindWell_NotificationService.Notification.Domain.Communication;
using MindWell_NotificationService.Notification.Domain.Services;
using MindWell_NotificationService.Notification.Resources.GET;
using MindWell_NotificationService.Notification.Resources.POST;
using MindWell_NotificationService.Shared.Extension;

namespace MindWell_NotificationService.Notification.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
public class NotificationsController : ControllerBase
{

    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public NotificationsController(INotificationService notificationService, IMapper mapper)
    {
        _notificationService = notificationService;
        _mapper = mapper;
    }
    
     [HttpGet]
    public async Task<IEnumerable<NotificationResource>> GetAllAsync()
    {
        var notifications = await _notificationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Domain.Models.Notification>, IEnumerable<NotificationResource>>(notifications);
        
        return resources;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var notification = await _notificationService.GetByIdAsync(id);

        if (notification == null)
            return NotFound(new NotificationResponse("Notification not found.").Message);
        
        var resource = _mapper.Map<Domain.Models.Notification, NotificationResource>(notification);
        
        return Ok(resource);
    }

    [HttpGet("user/{id:int}")]
    public async Task<IActionResult> GetAllByUserIdAsync(int id)
    {
        var notifications = await _notificationService.ListAllByUserIdAsync(id);
        
        if (notifications == null)
            return NotFound(new NotificationResponse("Notification not found.").Message);
        
        var resources = _mapper.Map<IEnumerable<Domain.Models.Notification>, IEnumerable<NotificationResource>>(notifications);
        
        return Ok(resources);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveNotificationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var notificationing = _mapper.Map<SaveNotificationResource, Domain.Models.Notification>(resource);
        var result = await _notificationService.SaveAsync(notificationing);

        if (!result.Success)
            return BadRequest(result.Message);

        var notificationingResource = _mapper.Map<Domain.Models.Notification, NotificationResource>(result.Resource);

        return Ok(notificationingResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveNotificationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var notificationing = _mapper.Map<SaveNotificationResource, Domain.Models.Notification>(resource);
        var result = await _notificationService.UpdateAsync(id, notificationing);

        if (!result.Success)
            return BadRequest(result.Message);

        var notificationingResource = _mapper.Map<Domain.Models.Notification, NotificationResource>(result.Resource);

        return Ok(notificationingResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _notificationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var notificationingResource = _mapper.Map<Domain.Models.Notification, NotificationResource>(result.Resource);

        return Ok(notificationingResource);
    }
}