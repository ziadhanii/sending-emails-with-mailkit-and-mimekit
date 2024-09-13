using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Options;
using Sending_Emails.Settings;

namespace Sending_Emails.Services
{
    public class MailingService : IMailingService
    {
        private readonly MailSettings _mailSettings;

        public MailingService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string bodyContent, IList<IFormFile>? attachments = null)
        {
            var emailMessage = CreateEmailMessage(recipientEmail, subject, bodyContent, attachments);

            using var smtpClient = new SmtpClient();
            try
            {
                await smtpClient.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                await smtpClient.AuthenticateAsync(_mailSettings.Email, _mailSettings.Password);
                await smtpClient.SendAsync(emailMessage);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to send email.", ex);
            }
            finally
            {
                await smtpClient.DisconnectAsync(true);
            }
        }

        private MimeMessage CreateEmailMessage(string recipientEmail, string subject, string bodyContent, IList<IFormFile>? attachments)
        {
            var emailMessage = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSettings.Email),
                Subject = subject
            };

            emailMessage.To.Add(MailboxAddress.Parse(recipientEmail));

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = bodyContent
            };

            if (attachments != null)
            {
                AttachFiles(bodyBuilder, attachments);
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            emailMessage.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));

            return emailMessage;
        }

        private void AttachFiles(BodyBuilder bodyBuilder, IList<IFormFile> attachments)
        {
            foreach (var file in attachments)
            {
                if (file.Length > 0)
                {
                    using var memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);
                    bodyBuilder.Attachments.Add(file.FileName, memoryStream.ToArray(), ContentType.Parse(file.ContentType));
                }
            }
        }
    }
}
