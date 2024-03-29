using Microsoft.AspNetCore.SignalR;
using Notifying.API.Controllers;
using Notifying.Infrastructure;
using Timer = System.Timers.Timer;

namespace Notifying.API.Services;

public class NotificationScheduler : IHostedService, IDisposable
{
    private readonly IEnumerable<Timer> _timers;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public NotificationScheduler(IServiceScopeFactory serviceScopeFactory)
    {
        _timers = new List<Timer>();
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await RefreshTimers();
    }

    public async Task RefreshTimers()
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            (this as IDisposable).Dispose();

            using var _context = scope.ServiceProvider.GetRequiredService<NotifyingContext>();
            foreach (var notification in _context.Notifications)
            {
                var timer = new Timer();
                var interval = (notification.TimeOfSending - DateTime.Now).TotalMilliseconds;
                if (interval > 0)
                {
                    timer.Interval = interval;
                    timer.Elapsed += async (sender, e) => await SendNotification(notification.Id);
                    timer.Start();
                    _timers.Append(timer);
                }
            }
        }
    }

    private async Task SendNotification(int notificationId)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var _context = scope.ServiceProvider.GetRequiredService<NotifyingContext>();
            var _hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<NotificationHub>>();
            var notification = _context.Notifications.FirstOrDefault(n => n.Id == notificationId);
            if (notification == null) return;
            var userIds = _context.Recipients.Where(un => un.NotificationId == notificationId).Select(un => un.UserId.ToString()).ToList();
            if (userIds.Count > 0) await _hubContext.Clients.Users(userIds).SendAsync("Receive", notification);
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        (this as IDisposable).Dispose();
    }

    void IDisposable.Dispose()
    {
        foreach (var timer in _timers)
        {
            timer.Dispose();
        }
    }
}