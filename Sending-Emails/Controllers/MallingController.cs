using Microsoft.AspNetCore.Mvc;
using Sending_Emails.DTOs;
using Sending_Emails.Services;
namespace Sending_Emails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailingService _mailingService;

        public EmailController(IMailingService mailingService)
        {
            _mailingService = mailingService;
        }

        [HttpPost("send-mail")]
        public async Task<IActionResult> SendEmailAsync([FromForm] EmailRequestDto emailRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mailingService.SendEmailAsync(
                    emailRequest.EmailTo,
                    emailRequest.Subject,
                    emailRequest.Body,
                    emailRequest.Attachments
                );
                return Ok("Email has been sent successfully.");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest($"Invalid argument: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Argument error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An internal server error occurred: {ex.Message}");
            }
        }

        [HttpPost("send-welcome-message")]
        public async Task<IActionResult> SendWelcomeEmailAsync([FromBody] WelcomeEmailRequestDto welcomeEmailRequest)
        {
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "EmailTemplate.html");

            if (!System.IO.File.Exists(templatePath))
            {
                return NotFound("Email template file not found.");
            }

            try
            {
                string emailTemplate;
                using (var reader = new StreamReader(templatePath))
                {
                    emailTemplate = await reader.ReadToEndAsync();
                }

                var emailBody = emailTemplate
                    .Replace("[username]", welcomeEmailRequest.Username)
                    .Replace("[email]", welcomeEmailRequest.Email);

                await _mailingService.SendEmailAsync(
                    welcomeEmailRequest.Email,
                    "Welcome to My Profile",
                    emailBody
                );
                return Ok("Welcome email has been sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An internal server error occurred: {ex.Message}");
            }
        }
    }
}
