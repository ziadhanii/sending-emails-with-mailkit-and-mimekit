using System.ComponentModel.DataAnnotations;

namespace Sending_Emails.DTOs
{
    public class WelcomeEmailRequestDto
    {

        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Email { get; set; }
    }
}
