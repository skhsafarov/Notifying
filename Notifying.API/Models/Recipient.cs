using Notifying.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Entity = Notifying.Domain.AggregatesModel.NotificationAggregate.Recipient;

namespace Notifying.API.Models
{
    public class Recipient
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public bool IsSent { get; set; }
        public DateTime TimeOfReading { get; set; }

        public static implicit operator Entity(Recipient recipient)
        {
            return new Entity
            {
                Id = recipient.Id,
                NotificationId = recipient.NotificationId,
                UserId = recipient.UserId,
                IsSent = recipient.IsSent,
                TimeOfReading = recipient.TimeOfReading
            };
        }

        public static implicit operator Recipient(Entity recipient)
        {
            return new Recipient
            {
                Id = recipient.Id,
                NotificationId = recipient.NotificationId,
                UserId = recipient.UserId,
                IsSent = recipient.IsSent,
                TimeOfReading = recipient.TimeOfReading
            };
        }
    }
}