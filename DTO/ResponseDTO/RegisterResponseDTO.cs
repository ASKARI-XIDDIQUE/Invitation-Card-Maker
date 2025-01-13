using System.ComponentModel.DataAnnotations;

namespace Invitation_Card_Maker.DTO.ResponseDTO
{
    public class RegisterResponseDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; } 
        public DateTime CreatedAt { get; set; }
        public string Role { get; set; }
    }
}
