using System.ComponentModel.DataAnnotations;

namespace Invitation_Card_Maker.DTO.RequestDTO
{
    public class VerifyOtpRequestDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Otp { get; set; }

      
    }
}
