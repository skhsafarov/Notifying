using Notifying.Domain.AggregatesModel.NotificationAggregate;

namespace Notifying.Infrastructure.Services
{
    public interface INotificationService
    {
        Task<Notification> CreateNotification(Notification notification);
        Task<Notification> DeleteNotification(int id);
        Task<Notification> GetNotification(int id);
        Task<IEnumerable<Notification>> GetNotifications();
        Task<IEnumerable<Notification>> GetNotifications(IEnumerable<int> ids);
        Task<Notification> UpdateNotification(Notification notification);
    }
}