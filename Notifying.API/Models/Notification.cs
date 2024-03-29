using System.Collections;
using Entity = Notifying.Domain.AggregatesModel.NotificationAggregate.Notification;

namespace Notifying.API.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string AttachedFiles { get; set; }
        public DateTime TimeOfSending { get; set; }

        public static implicit operator Entity(Notification notification)
        {
            return new Entity
            {
                Id = notification.Id,
                Title = notification.Title,
                Body = notification.Body,
                AttachedFiles = notification.AttachedFiles,
                TimeOfSending = notification.TimeOfSending
            };
        }

        public static implicit operator Notification(Entity notification)
        {
            return new Notification
            {
                Id = notification.Id,
                Title = notification.Title,
                Body = notification.Body,
                AttachedFiles = notification.AttachedFiles,
                TimeOfSending = notification.TimeOfSending,
            };
        }
    }
}