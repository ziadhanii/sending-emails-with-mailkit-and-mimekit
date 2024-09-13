using System.ComponentModel.DataAnnotations;

namespace Sending_Emails.DTOs
{
    public class EmailRequestDto
    {
        [Required]
        public required string EmailTo { get; set; }
        [Required]
        public required string Subject { get; set; }
        [Required]
        public required string Body { get; set; }

        public IList<IFormFile>? Attachments { get; set; }

    }
}
