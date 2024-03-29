using Notifying.Domain.AggregatesModel.NotificationAggregate;

namespace Notifying.Infrastructure.Services
{
    public interface IRecipientService
    {
        Task<Recipient> CreateRecipient(Recipient recipient);

        Task<Recipient> DeleteRecipient(int id);

        Task<Recipient> GetRecipient(int id);

        Task<IEnumerable<Recipient>> GetRecipients();

        Task<IEnumerable<Recipient>> GetRecipientsByNotificationId(int notificationId);

        Task<IEnumerable<Recipient>> GetRecipientsByUserId(int userId);

        Task<Recipient> UpdateRecipient(Recipient recipient);
    }
}