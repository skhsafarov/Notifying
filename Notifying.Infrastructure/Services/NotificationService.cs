using Microsoft.EntityFrameworkCore;
using Notifying.Domain.AggregatesModel.NotificationAggregate;

namespace Notifying.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NotifyingContext _notifyingContext;

        public NotificationService(NotifyingContext notifyingContext)
        {
            _notifyingContext = notifyingContext;
        }

        public async Task<Notification> CreateNotification(Notification notification)
        {
            _notifyingContext.Notifications.Add(notification);
            await _notifyingContext.SaveChangesAsync();
            return notification;
        }

        public async Task<Notification> GetNotification(int id)
        {
            var notification = await _notifyingContext.Notifications.FindAsync(id);
            return notification;
        }

        public async Task<IEnumerable<Notification>> GetNotifications()
        {
            return await _notifyingContext.Notifications.ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetNotifications(IEnumerable<int> ids)
        {
            return await _notifyingContext.Notifications.Where(n => ids.Contains(n.Id)).ToListAsync();
        }

        public async Task<Notification> UpdateNotification(Notification notification)
        {
            _notifyingContext.Update<Notification>(notification);
            await _notifyingContext.SaveChangesAsync();
            return notification;
        }

        public async Task<Notification> DeleteNotification(int id)
        {
            var notification = await _notifyingContext.Notifications.FindAsync(id);
            _notifyingContext.Notifications.Remove(notification);
            await _notifyingContext.SaveChangesAsync();
            return notification;
        }
    }
}