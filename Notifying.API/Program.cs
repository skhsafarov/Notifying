using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

using Notifying.API.Controllers;
using Notifying.API.Extensions;
using Notifying.API.Services;
using Notifying.Infrastructure;
using Notifying.Infrastructure.Services;

namespace Notifying.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuthenticationBearerToken();
        builder.Services.AddAuthorization();
        builder.Services.AddSignalR();
        builder.Services.AddDbContext<NotifyingContext>();
        builder.Services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
        builder.Services.AddScoped<INotificationService, NotificationService>();
        builder.Services.AddScoped<IRecipientService, RecipientService>();
        builder.Services.AddHostedService<NotificationScheduler>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseDefaultFiles();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapHub<NotificationHub>("/notification");
        app.Run();
    }
}

public class AuthOptions
{
    public const int EXPIRE_MINUTES = 360;
    public const int EXPIRE_MINUTES_REFRESH = 360;
    public const string PARAM_ISS = "GENESIS_INNOVATION";
    public const string PARAM_AUD = "GENESIS_INNOVATION_CLIENT";
    public const string PARAM_SECRET_KEY = "Y2F0Y2hugdyydtKLSJSAI&56SA#m5ldA==";
    public const int MAX_DEVICE_COUNT = 3;
}