using System.ComponentModel.DataAnnotations;

namespace Invitation_Card_Maker.DTO.RequestDTO
{
    public class RegisterRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[!@#$%^&*(),.?""':{}|<>]).*$", ErrorMessage = "The Password must contain at least one special character.")]
        public string Password { get; set; }
    }
}
