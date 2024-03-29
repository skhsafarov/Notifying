using Microsoft.EntityFrameworkCore;
using Notifying.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Notifying.Domain.AggregatesModel.NotificationAggregate
{
    public class Notification : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Attachment AttachedFiles { get; set; }
        public DateTime TimeOfSending { get; set; }
        public List<Recipient> Recipients { get; set; }
    }
}