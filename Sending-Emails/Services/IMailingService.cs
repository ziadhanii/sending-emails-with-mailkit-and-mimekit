namespace Sending_Emails.Services
{
    public interface IMailingService
    {
        Task SendEmailAsync(string mailto, string subject, string body, IList<IFormFile>? attachment = null );
    }
}
