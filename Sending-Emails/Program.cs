using MailKit;
using Microsoft.Extensions.Configuration;
using Sending_Emails.Services;
using Sending_Emails.Settings;

namespace Sending_Emails
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Configure Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure Email settings
            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("EmailSettings"));

            // Add MailingService
            builder.Services.AddTransient<IMailingService, MailingService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
