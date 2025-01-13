using System.ComponentModel.DataAnnotations;

namespace Invitation_Card_Maker.DTO.RequestDTO
{
    public class AuthRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
