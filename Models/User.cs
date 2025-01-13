using System.ComponentModel.DataAnnotations;

namespace Invitation_Card_Maker.Models
{
    public class User:BaseClass
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<UserTemplate> UserTemplate { get; set; }
        public ICollection<CustomTemplates> CustomTemplates { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? ResetPasswordOtp { get; set; }
        public DateTime? ResetPasswordOtpExpiryTime { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
