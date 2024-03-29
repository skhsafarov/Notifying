using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Notifying.Domain.AggregatesModel.NotificationAggregate;
using System.Reflection;
using System.Security.Cryptography;

namespace Notifying.Infrastructure
{
    public class NotifyingContext : DbContext
    {
        private readonly IConfiguration? configuration;

        public NotifyingContext(DbContextOptions<NotifyingContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration=configuration;
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Recipient> Recipients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Получть путь к проекту Notifying.API
                var path = $"Data Source={Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.Parent.FullName}\\\\SQLiteTestDb.db";
                optionsBuilder.UseSqlite(path/*configuration?.GetConnectionString("DefaultConnection")*/ ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."), x => x.MigrationsAssembly("Notifying.API"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // настройка несобственного свойства Attachment
            builder.Entity<Notification>().OwnsOne<Attachment>(p => p.AttachedFiles);

            builder.Entity<Notification>().HasData(
                new Notification[] {
                new Notification { Id = 1, Title = "Title1", Body = "Body1", TimeOfSending = DateTime.Now.AddMinutes(RandomNumberGenerator.GetInt32(1, 100))},
                new Notification { Id = 2, Title = "Title2", Body = "Body2", TimeOfSending = DateTime.Now.AddMinutes(RandomNumberGenerator.GetInt32(1, 100))},
                new Notification { Id = 3, Title = "Title3", Body = "Body3", TimeOfSending = DateTime.Now.AddMinutes(RandomNumberGenerator.GetInt32(1, 100))},
                new Notification { Id = 4, Title = "Title4", Body = "Body4", TimeOfSending = DateTime.Now.AddMinutes(RandomNumberGenerator.GetInt32(1, 100))},
                new Notification { Id = 5, Title = "Title5", Body = "Body5", TimeOfSending = DateTime.Now.AddMinutes(RandomNumberGenerator.GetInt32(1, 100))},
                new Notification { Id = 6, Title = "Title6", Body = "Body6", TimeOfSending = DateTime.Now.AddMinutes(RandomNumberGenerator.GetInt32(1, 100))},
                new Notification { Id = 7, Title = "Title7", Body = "Body7", TimeOfSending = DateTime.Now.AddMinutes(RandomNumberGenerator.GetInt32(1, 100))},
                new Notification { Id = 8, Title = "Title8", Body = "Body8", TimeOfSending = DateTime.Now.AddMinutes(RandomNumberGenerator.GetInt32(1, 100))},
                new Notification { Id = 9, Title = "Title9", Body = "Body9", TimeOfSending = DateTime.Now.AddMinutes(RandomNumberGenerator.GetInt32(1, 100))},
                new Notification { Id = 10, Title = "Title10", Body = "Body10", TimeOfSending = DateTime.Now.AddMinutes(RandomNumberGenerator.GetInt32(1, 100))}
                });

            // заполним принадлежащие типы данными
            builder.Entity<Notification>().OwnsOne(p => p.AttachedFiles).HasData(
                new { NotificationId = 1, JsonData = "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]" },
                new { NotificationId = 2, JsonData = "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]" },
                new { NotificationId = 3, JsonData = "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]" },
                new { NotificationId = 4, JsonData = "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]" },
                new { NotificationId = 5, JsonData = "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]" },
                new { NotificationId = 6, JsonData = "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]" },
                new { NotificationId = 7, JsonData = "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]" },
                new { NotificationId = 8, JsonData = "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]" },
                new { NotificationId = 9, JsonData = "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]" },
                new { NotificationId = 10, JsonData = "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]" }
            );

            builder.Entity<Recipient>().HasData(
                new Recipient[]
                {
                    new Recipient { Id = 1, NotificationId = 1, UserId = 1 },
                    new Recipient { Id = 2, NotificationId = 2, UserId = 1 },
                    new Recipient { Id = 3, NotificationId = 3, UserId = 1 },
                    new Recipient { Id = 4, NotificationId = 4, UserId = 1 },
                    new Recipient { Id = 5, NotificationId = 5, UserId = 1 },
                    new Recipient { Id = 6, NotificationId = 6, UserId = 1 },
                    new Recipient { Id = 7, NotificationId = 7, UserId = 1 },
                    new Recipient { Id = 8, NotificationId = 8, UserId = 1 },
                    new Recipient { Id = 9, NotificationId = 9, UserId = 1 },
                    new Recipient { Id = 10, NotificationId = 10, UserId = 1 },
                });
        }
    }
}