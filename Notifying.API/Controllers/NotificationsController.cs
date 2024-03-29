using Microsoft.AspNetCore.Mvc;
using Notifying.API.Models;
using Notifying.API.Services;
using Notifying.Infrastructure.Services;

namespace Notifying.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IHostedService _notificationScheduler;

        public NotificationsController(INotificationService notificationService, IHostedService notificationScheduler)
        {
            _notificationService = notificationService;
            _notificationScheduler = notificationScheduler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications()
        {
            return Ok(_notificationService.GetNotifications().Result.Select(x => (Notification)x));
        }

        [HttpPost]
        public async Task<ActionResult<Notification>> PostNotification(Notification notification)
        {
            Notification newNotification = await _notificationService.CreateNotification(notification);
            if (_notificationScheduler is NotificationScheduler notificationScheduler)
            {
                await notificationScheduler.RefreshTimers();
            }
            return CreatedAtAction(nameof(GetNotification), new { id = newNotification.Id }, newNotification);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetNotification(int id)
        {
            var notification = await _notificationService.GetNotification(id);
            if (notification == null)
            {
                return NotFound();
            }
            return (Notification)notification;
        }

        [HttpPut]
        public async Task<IActionResult> PutNotification(Notification notification)
        {
            await _notificationService.UpdateNotification(notification);
            if (_notificationScheduler is NotificationScheduler notificationScheduler)
            {
                await notificationScheduler.RefreshTimers();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var notification = await _notificationService.DeleteNotification(id);
            if (notification == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}