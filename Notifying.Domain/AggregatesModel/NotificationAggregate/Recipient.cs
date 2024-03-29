using Notifying.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Notifying.Domain.AggregatesModel.NotificationAggregate
{
    public class Recipient : Entity
    {
        [ForeignKey("Notification")]
        public int NotificationId { get; set; }

        public int UserId { get; set; }
        public bool IsSent { get; set; }
        public DateTime TimeOfReading { get; set; }
        public Notification Notification { get; set; }
    }
}