using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Notifying.API.Models;
using Notifying.Infrastructure.Services;

namespace Notifying.API.Controllers
{
    [Authorize]
    public class NotificationHub : Hub
    {
        private readonly INotificationService _notificationService;
        private readonly IRecipientService _recipientService;

        public NotificationHub(INotificationService notificationService, IRecipientService recipientService)
        {
            _notificationService = notificationService;
            _recipientService = recipientService;
        }

        public override async Task OnConnectedAsync()
        {
            if (int.TryParse(Context.UserIdentifier, out var userId))
            {
                var notificationIds = _recipientService.GetRecipientsByUserId(userId).Result.Select(x => x.NotificationId);
                var notifications = _notificationService.GetNotifications(notificationIds).Result.Select(x => (Notification)x);
                await Clients.Caller.SendAsync("ReceiveAll", notifications);
            }
            await base.OnConnectedAsync();
        }
    }
}