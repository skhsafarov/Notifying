using Microsoft.EntityFrameworkCore;
using Notifying.Domain.AggregatesModel.NotificationAggregate;

namespace Notifying.Infrastructure.Services
{
    public class RecipientService : IRecipientService
    {
        private readonly NotifyingContext _notifyingContext;

        public RecipientService(NotifyingContext notifyingContext)
        {
            _notifyingContext = notifyingContext;
        }

        public async Task<Recipient> CreateRecipient(Recipient recipient)
        {
            _notifyingContext.Recipients.Add(recipient);
            await _notifyingContext.SaveChangesAsync();
            return recipient;
        }

        public async Task<Recipient> GetRecipient(int id)
        {
            var recipient = await _notifyingContext.Recipients.FindAsync(id);
            return recipient;
        }

        public async Task<IEnumerable<Recipient>> GetRecipients()
        {
            return await _notifyingContext.Recipients.ToListAsync();
        }

        public async Task<IEnumerable<Recipient>> GetRecipientsByNotificationId(int notificationId)
        {
            return await _notifyingContext.Recipients.Where(r => r.NotificationId == notificationId).ToListAsync();
        }

        public async Task<IEnumerable<Recipient>> GetRecipientsByUserId(int userId)
        {
            return await _notifyingContext.Recipients.Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task<Recipient> UpdateRecipient(Recipient recipient)
        {
            _notifyingContext.Update<Recipient>(recipient);
            await _notifyingContext.SaveChangesAsync();
            return recipient;
        }

        public async Task<Recipient> DeleteRecipient(int id)
        {
            var recipient = await _notifyingContext.Recipients.FindAsync(id);
            _notifyingContext.Recipients.Remove(recipient);
            await _notifyingContext.SaveChangesAsync();
            return recipient;
        }
    }
}