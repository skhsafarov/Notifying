using Microsoft.EntityFrameworkCore;
using Notifying.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Notifying.Domain.AggregatesModel.NotificationAggregate
{
    [Owned]
    public class Attachment : ValueObject
    {
        [NotMapped]
        public List<string> FileUrls { get; set; }

        public string? JsonData
        {
            get
            {
                string value;
                try
                {
                    value = JsonSerializer.Serialize(FileUrls);
                }
                catch (Exception)
                {
                    value = null;
                }
                return value;
            }
            set
            {
                try
                {
                    FileUrls = JsonSerializer.Deserialize<List<string>>(value);
                }
                catch (Exception)
                {
                    FileUrls = new List<string>();
                }
            }
        }

        public static implicit operator Attachment(string jsonData)
        {
            return new Attachment
            {
                JsonData = jsonData
            };
        }

        public static implicit operator string(Attachment attachment)
        {
            return attachment.JsonData;
        }

        public override string ToString()
        {
            return JsonData;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return JsonData;
        }
    }
}